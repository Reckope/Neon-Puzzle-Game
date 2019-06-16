/* 
* Author: Joe Davis
* Project: Neon Puzzle Game
* 2019
* Notes: 
* Attach this script to the buttons used to load scenes. Button name needs to match the
* name of the scene it's loading. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
	//Global Variables
	private string sceneName;

	// ------------------------------------------------------------------------------
	void Start()
	{
		sceneName = this.gameObject.name;
	}

	// We load the scene depending on what button was selected. If
	// the scene doesn't exist, log the error. 
	public void LoadScene()
	{
		if(this.gameObject.name == "ExitGame")
		{
			Application.Quit();
		}
		else
		{
			if(Application.CanStreamedLevelBeLoaded(sceneName))
			{
				SceneManager.LoadScene(sceneName);
			}
			else
			{
				Debug.Log("ERROR: Scene " + sceneName + " does not exist.");
			}
		}
	}
}