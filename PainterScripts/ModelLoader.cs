using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGamePro;
public class ModelLoader : MonoBehaviour {
	//model to paint's position
	[SerializeField]
	Transform modelTransform;
	[SerializeField]
	//the camera orbiter
	SmoothOrbitCam orbiter;

	// Use this for initialization
	void Start () {

		GameObject model = null;
		if (Globals.isUserModel && SaveGame.Exists (Globals.modelName))
		{
			model = SaveGame.Load<GameObject> (Globals.modelName);
			orbiter.target = model.transform;

		}
		else if ((Globals.isUserModel) && (!SaveGame.Exists (Globals.modelName)))
			return;
		else
		{
			model = Resources.Load<GameObject> (Globals.modelsPath + "/" + Globals.modelName);
			GameObject instantiatedModel = Instantiate (model, modelTransform.position, Quaternion.identity);
			orbiter.target = instantiatedModel.transform;

			return;
		}
		

	}
	public void LoadModelSelectorScene()
	{
		SceneManager.LoadScene ("ModelSelectScene");
	}
}
