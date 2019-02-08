using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GestureManager : MonoBehaviour {
	[SerializeField]
	Image gestureImage;
	[SerializeField]
	Color toggledColor;
	[SerializeField]
	Color untoggleColor;
	[SerializeField]
	Toggle gestureToggle;
	[SerializeField]
	SmoothOrbitCam orbiter;
	void Start()
	{
		orbiter.enableZooming = gestureToggle.isOn;
		orbiter.EnableOrbiting = gestureToggle.isOn;
		if (gestureToggle.isOn)
			gestureImage.color= toggledColor;
		else
			gestureImage.color= untoggleColor;
	}

	public void OnGestureToggled(bool isEnabled)
	{
		orbiter.enableZooming = isEnabled;
		orbiter.EnableOrbiting = isEnabled;
		if (isEnabled)
			gestureImage.color= toggledColor;
		else
			gestureImage.color= untoggleColor;
	}
}
