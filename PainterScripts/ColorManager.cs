using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ColorManager : MonoBehaviour
{
	public delegate void ColorChangeEventHandler(Color32 color);
	public event ColorChangeEventHandler colorChanged;

	public void OnColorChanged(Color32 color)
	{
		if(colorChanged!=null)
			colorChanged (color);
	}
}
