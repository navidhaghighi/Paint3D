using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriLib.Samples;
using MalbersAnimations.Selector;
using BayatGames.SaveGamePro;
using BayatGames.SaveGamePro.IO;
public class ModelLoadManager : MonoBehaviour {
	List<string> userModelsIdentifiers;
	private const string userModelsIdentifiersKey = "model_names";
	[SerializeField]
	Material emptyMaterial;
	[SerializeField]
	SelectorManager selectorManager;
	[SerializeField]
	GameObject modelParent;
	[SerializeField]
	AssetLoaderWindow loader;
	// Use this for initialization
	void Start () {
		if(loader)
		loader.modelLoaded += OnModelLoaded;
		LoadModelsFromResources ();
		LoadUserModels ();
	}
	void OnDisable()
	{
		if((userModelsIdentifiers!=null)&& userModelsIdentifiers.Count>0)
			SaveGame.Save<List<string>> (userModelsIdentifiersKey,userModelsIdentifiers);
	}
	void LoadUserModels()
	{
		userModelsIdentifiers =  SaveGame.Load<List<string >> (userModelsIdentifiersKey);
		if (userModelsIdentifiers == null) {
			userModelsIdentifiers = new List<string> ();
			return;
		}
		foreach (string identifier in userModelsIdentifiers) {
			GameObject model = null;
			if (SaveGame.Exists (identifier)) {
				model = SaveGame.Load<GameObject> (identifier);
				selectorManager._AddItem (model);
				Destroy (model.transform.parent.gameObject);
			}
		}
	}
	void LoadModelsFromResources()
	{
		GameObject[] models = Resources.LoadAll<GameObject> (Globals.modelsPath);
		foreach (GameObject model in models) {
			
			selectorManager._AddItem (model);
		}
		FixNames ();
	}
	//fix items children names 
	void FixNames()
	{
		foreach (Transform t in modelParent.transform) {
			if (t.gameObject.name.Contains ("(Clone)")) {
				t.gameObject.name = t.gameObject.name.Replace ("(Clone)", "");
			}
		}
	}
	//on user model loaded .
	void OnModelLoaded(GameObject model)
	{
		if (model == null)
			return;
		GameObject modelChild=null;

		if (model.transform.GetChild (0)) {
			modelChild = model.transform.GetChild(0).gameObject;
		}
		if (modelChild==null)
			return;
		modelChild.AddComponent<ModelInfo> ();
		modelChild.GetComponent<ModelInfo> ().isUserModel = true;



		Renderer[] renderers = modelChild.GetComponentsInChildren<Renderer> (true);

		foreach (Renderer renderer in renderers) {
			renderer.material = new Material (emptyMaterial);
			renderer.gameObject.AddComponent<P3D_Paintable> ();
			/*foreach (P3D_PaintableTexture texture in renderer.gameObject.GetComponent<P3D_Paintable>().Textures) {

				texture.CreateOnAwake = true;
				texture.CreateWidth = 2048;
				texture.CreateHeight = 2048;

			}*/
		}

		SaveGameSettings settings = new SaveGameSettings ();
		settings.Identifier = modelChild.name;
		SaveGame.Save (modelChild.name,modelChild);
		userModelsIdentifiers.Add (modelChild.name);
		selectorManager._AddItem (modelChild);
		Destroy (model);

		FixNames ();


	}

}
