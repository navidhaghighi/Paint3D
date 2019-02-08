using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotHandler : MonoBehaviour
{
	[SerializeField]
	AndroidSocialNativeExample native;
	[SerializeField]
	GameObject ui;


    public void SaveScreenShot()
    {
		if(ui)
		ui.SetActive (false);
        AndroidCamera.Instance.OnImageSaved += OnImageSaved;
        AndroidCamera.Instance.SaveScreenshotToGallery("Screenshot" + AndroidCamera.GetRandomString());
	
		native.ShareScreehshot ();
    }
	void OnImageSaved(GallerySaveResult result)
    {
		if(result.IsSucceeded)
			AndroidToast.ShowToastNotification(Globals.imageSaveMsg + result.imagePath, AndroidToast.LENGTH_LONG);
		else AndroidToast.ShowToastNotification(Globals.imageSaveFailMsg+ result.imagePath, AndroidToast.LENGTH_LONG);
		if (ui)
			ui.SetActive (true);
		
    }
}
