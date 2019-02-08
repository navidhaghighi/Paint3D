using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BrushManager : MonoBehaviour {
	[SerializeField]
	Slider brushSize;

	public delegate void BrushSizeChangeEventHandler(Vector2  value);
	public event BrushSizeChangeEventHandler brushSizeChanged;

	public delegate void BrushImageChangeEventHandler(Texture2D image);
	public event BrushImageChangeEventHandler brushImageChanged;
	// Use this for initialization
	void Start () {

	}

	public void OnBrushSizeSliderChanged()
	{
		ChangeBrushSize (brushSize.value);
	}
	public void ChangeBrushSize(float value)
	{
		Vector2 size = new Vector2 (value, value);
		if (brushSizeChanged != null)
			brushSizeChanged (size);
		Globals.currentBrushSize = size;
	}
	public void ChangeBrushTexture(Image brushImage)
	{
		if (brushImageChanged != null)
			brushImageChanged ((Texture2D)brushImage.mainTexture);
		Globals.currentBrushTexture =(Texture2D) brushImage.mainTexture;
	}
}
