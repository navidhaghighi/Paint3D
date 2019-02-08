using UnityEngine;
using UIWidgets;
/*
#if UNITY_EDITOR
[UnityEditor.CanEditMultipleObjects]
[UnityEditor.CustomEditor(typeof(P3D_ClickToPaint))]
public class P3D_ClickToPaint_Editor : P3D_Editor<P3D_ClickToPaint>
{
	
	protected override void OnInspector()
	{

		DrawDefault("Requires");

		DrawDefault("LayerMask");

		DrawDefault("GroupMask");

		DrawDefault("Paint");

		DrawDefault("Brush");
	}
}
#endif
*/
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class P3D_ClickToPaint : MonoBehaviour
{
	[SerializeField]
	Slider brushSizeSlider;
	[SerializeField]
	ColorPicker colorPicker;
	[SerializeField]
	BrushManager brushManager;
	[SerializeField]
	ColorManager colorManager;
	public enum NearestOrAll
	{
		Nearest,
		All
	}

	[Tooltip("The key that must be held down to mouse look")]
	public KeyCode Requires = KeyCode.Mouse0;

	[Tooltip("The GameObject layers you want to be able to paint")]
	public LayerMask LayerMask = -1;

	[Tooltip("The paintable texture groups you want to be able to paint")]
	public P3D_GroupMask GroupMask = -1;

	[Tooltip("Which surfaces it should hit")]
	public NearestOrAll Paint;

	[Tooltip("The settings for the brush we will paint with")]
	public P3D_Brush Brush;
	void Start()
	{
		if (brushSizeSlider)
			brushSizeSlider.value = Brush.Size.x;
		if (colorPicker)
			colorPicker.Color = Brush.Color;
		if (brushManager) {
			brushManager.brushImageChanged += OnBrushTextureChanged;
			brushManager.brushSizeChanged += OnBrushSizeChanged;
		}
		if(colorManager)
		colorManager.colorChanged += OnColorChanged;
	}

	void OnBrushSizeChanged(Vector2 size)
	{
		Brush.Size = size;
	}
	void OnBrushTextureChanged(Texture2D image)
	{
		Brush.Shape = image;
	}
	void OnColorChanged(Color32 color)
	{
		Brush.Color = color;
	}
	//Called every frame
	protected virtual void Update()
	{
		var mainCamera = Camera.main;

		if (mainCamera != null)
		{
			// The required key is down?
			if (Input.GetKey(Requires) == true)
			{
				if (EventSystem.current.IsPointerOverGameObject ())
					return;
				var ray   = mainCamera.ScreenPointToRay(Input.mousePosition);
				var start = ray.GetPoint(mainCamera.nearClipPlane);
				var end   = ray.GetPoint(mainCamera.farClipPlane);

				// Paint between the start and end points
				switch (Paint)
				{
					case NearestOrAll.Nearest:
					{
						P3D_Paintable.ScenePaintBetweenNearest(Brush, start, end, LayerMask, GroupMask);
					}
					break;

					case NearestOrAll.All:
					{
						P3D_Paintable.ScenePaintBetweenAll(Brush, start, end, LayerMask, GroupMask);
					}
					break;
				}
			}
		}
	}
}
