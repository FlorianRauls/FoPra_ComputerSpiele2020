using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiPlayerMenu : MenuView
{
	public void NewGame()
	{
		ProfileManager.GetInstance().GetProfile().SetCurrentLevelM(1);
		LevelLoader.singleplayer = false;
		SceneManager.LoadScene("Game");
	}

	public void Continue()
	{
		LevelLoader.levelIndex = ProfileManager.GetInstance().GetProfile().GetCurrentLevelM();
		LevelLoader.singleplayer = false;
		SceneManager.LoadScene("Game");
	}

	public void LevelSelect()
	{
		LevelLoader.singleplayer = false;
		TransitionToLevelSelect();
	}
}
