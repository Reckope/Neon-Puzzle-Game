/* 
* Author: Joe Davis
* Project: Neon Puzzle Game
* 2019
* Notes: 
* This is used to manage the main menu. Attach it to the menu option buttons, as
* well as an empty gameobject to get the menu options.  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
	public GameObject[] menuOptions;
	private enum menuOptionsEnum
	{
		welcome = 0,
		selectLevel = 1,
		howToPlay = 2,
		settings = 3,
		credits = 4
	};
	private int menuUI;

	// ------------------------------------------------------------------------------
	void Start()
	{
		HideAllMenuOptions();
		menuUI = (int)menuOptionsEnum.selectLevel;
		DisplayMenuOption(menuUI);
		//menuOptions[menuUI].SetActive(true);
	}

	// Each menu button passes over a value to display their respected UI.
	// If it exists, display. Else, log error.  
	public void DisplayMenuOption(int menuOption)
	{
		menuOptionsEnum optionActivated = (menuOptionsEnum)menuOption;
		Debug.Log("Option Activated: " + optionActivated);
		HideAllMenuOptions();
		if(menuOption < menuOptions.Length && menuOptions[menuOption] != null)
		{
			menuOptions[menuOption].SetActive(true);
		}
		else
		{
			Debug.Log("ERROR: Menu option '" + menuOption + "' doesn't exist.");
		}
	}

	private void HideAllMenuOptions()
	{
		for(int i = 0; i < menuOptions.Length; i++)
		{
			menuOptions[i].SetActive(false);
		}
	}
}
