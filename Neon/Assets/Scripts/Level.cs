/* 
* Author: Joe Davis
* Project: Neon Puzzle Game
* 2019
* Notes: 
* This is used to display the unlocked level and it's data, or disable it if not unlocked yet. 
* Attach this to a level UI button. 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Level : MonoBehaviour
{
	// Components
	public Sprite lockedLevelSprite;
	public Text levelNumberText;
	private Button levelButton;
	private Image levelImage;

	// GameObjects
	public Text levelInformation;

	// Global Variables
	public string levelID;
	public string levelName;
	public string objective;
	public int buildIndex;
	public bool isUnlocked;
	public bool isActive;
	public bool completed;

	// ------------------------------------------------------------------------------
	// During Awake(), the LevelController.cs Initializes each level, and constructs it here.  
	public void ConstructLevel(string id, string name, string objective, int buildIndex, bool isUnlocked, bool isActive, bool completed)
	{
		this.levelID = id;
		this.levelName = name;
		this.objective = objective;
		this.buildIndex = buildIndex;
		this.isUnlocked = isUnlocked;
		this.isActive = isActive;
		this.completed = completed;
	}

	void Start()
	{
		Debug.Log("Level made: " + isActive);
		levelButton = GetComponent<Button>();
		levelImage = GetComponent<Image>();
		EnableLevel();
		levelInformation.text = null;
	}

	// We then enable the level depending on if it's unlocked or not. 
	public void EnableLevel()
	{
		levelNumberText.text = buildIndex.ToString();

		if(isUnlocked)
		{
			levelButton.enabled = true;
			levelNumberText.gameObject.SetActive(true);
		}
		else
		{
			levelImage.sprite = lockedLevelSprite;
			levelButton.enabled = false;
			levelNumberText.gameObject.SetActive(false);
		}
	}

	// Display the level information whilst the player hovers over the 
	// level button. 
	public void DisplayLevelInformation()
	{
		if(levelInformation != null)
		{
			if(this.isUnlocked)
			{
				levelInformation.text = levelName;
			}
			else
			{
				levelInformation.text = "LOCKED";
			}
		}
		else
		{
			Debug.Log("Missing Object Reference: Text levelInformation");
		}
	}

	public void HideLevelInformation()
	{
		levelInformation.text = null;
	}
}
