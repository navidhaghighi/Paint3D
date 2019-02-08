using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIElementManager : MonoBehaviour {
	[SerializeField]
	Toggle[] toggles;
	[SerializeField]
	GameObject eraserSizeUI;
	[SerializeField]
	GameObject eraserTypeUI;

	[SerializeField]
	GameObject brushSizeUI;
	[SerializeField]
	GameObject brushTypeUI;

	[SerializeField]
	GameObject Dismisser;
	[SerializeField]
	GameObject brushColorPicker;
	[SerializeField]
	GameObject fillColorPicker;
	// Use this for initialization
	void Start () {
		
	}
	public void ActivateDismisser()
	{
		Dismisser.SetActive (true);
	}
	public void DismissAll()
	{
		foreach (Toggle toggle in toggles) {
			toggle.isOn = false;
		}
		if (brushColorPicker)
			brushColorPicker.SetActive (false);

		if (fillColorPicker)
			fillColorPicker.SetActive (false);

		if (brushColorPicker)
			brushColorPicker.SetActive (false);

		 if(eraserSizeUI)
			eraserSizeUI.SetActive (false);

		 if( eraserTypeUI)
			eraserTypeUI.SetActive (false);

		if( brushSizeUI)
			brushSizeUI.SetActive (false);

		if( brushTypeUI)
			brushTypeUI.SetActive (false);

		Dismisser.SetActive (false);
	}
	public void HideBrushColorPicker()
	{
		if (brushColorPicker)
			brushColorPicker.SetActive (false);
		Dismisser.SetActive (false);
	}
	public void HideFillColorPicker()
	{
		if (brushColorPicker)
			brushColorPicker.SetActive (false);
		Dismisser.SetActive (false);
	}



	public void StartEraserUIAnimation(Toggle toggle)
	{
		Dismisser.SetActive (toggle.isOn);

		if (toggle.isOn && eraserSizeUI)
			eraserSizeUI.SetActive (true);
		else if(!toggle.isOn && eraserSizeUI)
			eraserSizeUI.SetActive (false);


		if (toggle.isOn && eraserTypeUI)
			eraserTypeUI.SetActive (true);
		else if(!toggle.isOn && eraserTypeUI)
			eraserTypeUI.SetActive (false);
	}

	public void StartBrushUIAnimation(Toggle toggle)
	{
		Dismisser.SetActive (toggle.isOn);


		if (toggle.isOn && brushSizeUI)
			brushSizeUI.SetActive (true);
		else if(!toggle.isOn && brushSizeUI)
			brushSizeUI.SetActive (false);

		if (toggle.isOn && brushTypeUI)
			brushTypeUI.SetActive (true);
		else if(!toggle.isOn && brushTypeUI)
			brushTypeUI.SetActive (false);
	}

	public void StartBrushColorPalleteAnimation(Toggle toggle)
	{
		Dismisser.SetActive (toggle.isOn);

		if (toggle.isOn && brushColorPicker)
			brushColorPicker.SetActive (true);
		else if(!toggle.isOn && brushColorPicker)
			brushColorPicker.SetActive (false);

	}

	public void StartFillColorPalleteAnimation(Toggle toggle)
	{
		Dismisser.SetActive (toggle.isOn);

		Debug.Log ("is it on " + toggle.isOn);
		if (toggle.isOn && fillColorPicker)
			fillColorPicker.SetActive (true);
		else if(!toggle.isOn && fillColorPicker)
			fillColorPicker.SetActive (false);

	}
}
