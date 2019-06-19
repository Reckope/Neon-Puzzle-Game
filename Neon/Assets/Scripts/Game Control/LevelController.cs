/* 
* Author: Joe Davis
* Project: Neon Puzzle Game
* 2019
* Notes: 
* This is used to manage the levels. Data can be loaded from a Json file.
* Attach this to the object that contains the level buttons.  
*/

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Structure of a Level.
[Serializable]
public class LevelStructure
{
	public string levelID;
	public string levelName;
	public string objective;
	public int buildIndex;
	public bool isUnlocked;
	public bool isActive;
	public bool completed;
}

// Data collection for the level. 
[Serializable]
public class LevelDataCollection
{
	public LevelStructure[] levels;
}

public class LevelController : MonoBehaviour
{
	// Classes
	LevelDataCollection allLevels;

	// Global Variables
	private int unlockedLevel;
	private Level[] levelButtons;

	// ------------------------------------------------------------------------------
	void Awake()
	{
		unlockedLevel = 2;
		levelButtons = GetComponentsInChildren<Level>();
		
		TextAsset txtAsset = (TextAsset)Resources.Load("LevelData", typeof(TextAsset));
		String levelData = txtAsset.text;
		allLevels = JsonUtility.FromJson<LevelDataCollection>(levelData);

		InitializeLevels();
		Debug.Log(allLevels.levels[1].levelID);
	}

	// After obtaining the level data, we construct each level in Level.cs.
	// Each level button will contain the data for the level it activates. 
	private void InitializeLevels()
	{
		for(int i = 0; i < levelButtons.Length; i++)
		{
			int level = i + 1;
			levelButtons[i].gameObject.SetActive(true);
			levelButtons[i].ConstructLevel(
				allLevels.levels[level].levelID, 
				allLevels.levels[level].levelName,
				allLevels.levels[level].objective,
				allLevels.levels[level].buildIndex,
				allLevels.levels[level].isUnlocked,
				allLevels.levels[level].isActive,
				allLevels.levels[level].completed
			);
		}
	}
}
