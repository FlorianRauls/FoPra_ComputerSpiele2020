using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiPlayerMenu : MenuView
{
	public void NewGame()
	{
		ProfileManager.GetInstance().GetProfile().SetCurrentLevelM(1);
		GameManager.singleplayer = false;
		SceneManager.LoadScene("Game");
	}

	public void Continue()
	{
		GameManager.levelIndex = ProfileManager.GetInstance().GetProfile().GetCurrentLevelM();
		GameManager.singleplayer = false;
		SceneManager.LoadScene("Game");
	}

	public void LevelSelect()
	{
		GameManager.singleplayer = false;
		TransitionToLevelSelect();
	}
}
