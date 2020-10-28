using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayerMenu : MenuView
{
	public void NewGame()
	{
		ProfileManager.GetInstance().GetProfile().SetCurrentLevelS(1);
		GameManager.levelIndex = 1;
		GameManager.singleplayer = true;
		SceneManager.LoadScene("Game");
	}

	public void Continue()
	{
		GameManager.levelIndex = ProfileManager.GetInstance().GetProfile().GetCurrentLevelS();
		GameManager.singleplayer = true;
		SceneManager.LoadScene("Game");
	}

	public void LevelSelect()
    {
		GameManager.singleplayer = true;
		TransitionToLevelSelect();
	}
}
