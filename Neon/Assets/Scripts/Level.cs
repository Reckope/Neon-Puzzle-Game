/* 
* Author: Joe Davis
* Project: Neon Puzzle Game
* 2019
* Notes: 
* This is used to display the unlocked level and it's data, or disable it if not unlocked yet. 
* Attach this to a level UI button. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	private int level;
	private bool isUnlocked;

	// ------------------------------------------------------------------------------
	// During Awake(), the LevelController.cs Initializes each level, and constructs it here.  
	public void ConstructLevel(int level, bool isUnlocked)
	{
		this.level = level;
		this.isUnlocked = isUnlocked;
	}

	void Start()
	{
		levelButton = GetComponent<Button>();
		levelImage = GetComponent<Image>();
		SetLevelData();
		levelInformation.text = null;
	}

	// We then set the level data to determine if the player has access to it.
	public void SetLevelData()
	{
		levelNumberText.text = level.ToString();

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
				levelInformation.text = this.level.ToString();
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
}
