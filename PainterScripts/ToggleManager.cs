using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour {
	[SerializeField]
	Color toggleOnColor;
	[SerializeField]
	Color toggleOffColor;
	[SerializeField]
	Toggle[] toggles;
	// Use this for initialization
	void Start () {
		foreach (Toggle toggle in toggles) {
			OnToggled (toggle.isOn);
			toggle.onValueChanged.AddListener ( OnToggled);
		}
	}

	public void OnToggled(bool isOn)
	{
		AlterTogglesAppearance ();
		
	}
	void AlterTogglesAppearance()
	{
		foreach (Toggle toggle in toggles) {
			if (toggle.isOn)
				toggle.image.color = toggleOnColor;
			else 
				toggle.image.color = toggleOffColor;

		}
	}
}
