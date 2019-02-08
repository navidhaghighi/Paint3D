using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIWidgets;
public class FillBrush : MonoBehaviour {
	[SerializeField]
	ColorPicker colorPicker;
	Color currentFillColor;
	[SerializeField]
	ColorManager colorManager;
	// Use this for initialization
	void Start () {
		if(colorPicker)
			currentFillColor = colorPicker.Color;
		if(colorManager)
			colorManager.colorChanged += OnFillColorChanged;
	}
	void OnFillColorChanged(Color32 color )
	{
		currentFillColor = colorPicker.Color;
	}
	public void FillAllModelTextures()
	{
		FillModelTextures (Globals.currentModel,currentFillColor);
	}
	void FillModelTextures(GameObject model,Color32 fillColor)
	{
		MeshRenderer[] meshes=  model.GetComponentsInChildren  <MeshRenderer>(true);
		foreach (MeshRenderer mesh in meshes) {
			Texture2D tex = (Texture2D) mesh.material.mainTexture;
			Color[] fillColorArray =  tex.GetPixels();

			for(var i = 0; i < fillColorArray.Length; ++i)
			{
				fillColorArray[i] = fillColor;
			}

			tex.SetPixels( fillColorArray );

			tex.Apply();
		}
	}

}
