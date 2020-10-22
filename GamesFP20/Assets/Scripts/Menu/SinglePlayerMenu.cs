using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayerMenu : MenuView
{
	public void NewGame()
	{
		ProfileManager.GetInstance().GetProfile().SetCurrentLevelS(1);
		LevelLoader.singleplayer = true;
		SceneManager.LoadScene("Game");
	}

	public void Continue()
	{
		LevelLoader.levelIndex = ProfileManager.GetInstance().GetProfile().GetCurrentLevelS();
		LevelLoader.singleplayer = true;
		SceneManager.LoadScene("Game");
	}

	public void LevelSelect()
    {
		LevelLoader.singleplayer = true;
		TransitionToLevelSelect();
	}
}
