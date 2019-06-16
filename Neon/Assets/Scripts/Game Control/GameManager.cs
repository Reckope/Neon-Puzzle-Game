/* 
* Author: Joe Davis
* Project: Neon Puzzle Game
* 2019
* Notes: 
* This is used to manage the game overall, and runs through every scene in the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	//Static instance of GameManager.
	public static GameManager instance;

	// Start is called before the first frame update
	void Start()
	{
		DontDestroyOnLoad(this.gameObject);
		CoreGameSettings();
	}

	// Instance / target framerate.
	private void CoreGameSettings()
	{
		// Target frame rate is 30 fps
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 300;
		// Singleton Pattern: There can only ever be one instance of a GameManager.
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
