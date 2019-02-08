using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    GameObject currentDialog;

    public void ShowDialog(GameObject dialog)
    {
        if (currentDialog)
            currentDialog.SetActive(false);
		dialog.SetActive(true);
    }
	public void OpenMainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}
	public void RateApp()
	{
		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");

		AndroidJavaClass uriClass = new AndroidJavaClass ("android.net.Uri");

		intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_EDIT"));
		intentObject.Call<AndroidJavaObject> ("setData", uriClass.CallStatic<AndroidJavaObject> ("parse","bazaar://details?id="+"com.navidapps.paint3d"));

		intentObject.Call<AndroidJavaObject> ("setPackage", "com.farsitel.bazaar");

		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		currentActivity.Call ("startActivity", intentObject);

	}
	public void ShowDevPage()
	{
		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");

		AndroidJavaClass uriClass = new AndroidJavaClass ("android.net.Uri");

		intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_VIEW"));
		intentObject.Call<AndroidJavaObject> ("setData", uriClass.CallStatic<AndroidJavaObject> ("parse", "bazaar://collection?slug=by_author&aid="+"navid_haghighi"));
		intentObject.Call<AndroidJavaObject> ("setPackage", "com.farsitel.bazaar");

		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		currentActivity.Call ("startActivity", intentObject);

	}

}
