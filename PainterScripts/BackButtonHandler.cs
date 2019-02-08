using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackButtonHandler : MonoBehaviour {
	[SerializeField]
	GameObject pauseMenu;
	// Use this for initialization
	void Start () {
		
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			switch (SceneManager.GetActiveScene ().name) {

			case "ModelSelectScene":
				{
					SceneManager.LoadScene ("MainMenu");
					break;
				}

			case "PaintScene":
				{
					if(pauseMenu)
					pauseMenu.SetActive (!pauseMenu.activeInHierarchy);
					break;
				}
					
			}
		}
	}

}
