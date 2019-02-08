using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour {

	//set all pixels white
	public void ClearTexture()
	{
		
		MeshRenderer[] meshes=  Globals.currentModel.GetComponentsInChildren  <MeshRenderer>(true);
		foreach (MeshRenderer mesh in meshes) {
			Texture2D tex = (Texture2D) mesh.material.mainTexture;
			Color fillColor = Color.white;
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
