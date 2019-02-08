using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ModelSelector : MonoBehaviour {

	public void OnModelFocused(GameObject model)
	{

		if (model.name.Contains ("(Clone)")) 
			model.name = model.name.Replace ("(Clone)", "");
			
		if (model.GetComponentInChildren <ModelInfo> ())
			Globals.isUserModel = model.GetComponentInChildren<ModelInfo> ().isUserModel;
		Globals.modelName = model.name;
	}
	public void SelectModel()
	{
		
		SceneManager.LoadScene ("PaintScene");
	}

}
