/* 
* Author: Joe Davis
* Project: Neon Puzzle Game
* 2019
* Notes: 
* This is used to manage the levels. Data can be loaded from a Json file.
* Attach this to the object that contains the level buttons.  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	// Global Variables
	private int totalNumberOfLevels = 6;
	private int unlockedLevel;
	private int startLevel = 0;
	private Level[] levelButtons;

	// ------------------------------------------------------------------------------
	void Awake()
	{
		unlockedLevel = 2;
		levelButtons = GetComponentsInChildren<Level>();
		InitializeLevel();
	}

	// After obtaining the level data, we construct each level in Level.cs.
	private void InitializeLevel()
	{
		for(int i = 0; i < levelButtons.Length; i++)
		{
			int level = startLevel + i + 1;
			levelButtons[i].gameObject.SetActive(true);
			levelButtons[i].ConstructLevel(level, level<=unlockedLevel);
		}
	}
}
