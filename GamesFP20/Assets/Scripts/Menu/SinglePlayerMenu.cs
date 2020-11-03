using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
///  This class is a child of MenuView and represents the Menu which is used for Starting or Loading a singleplayer game.
/// </summary>
public class SinglePlayerMenu : MenuView
{
	///Starts a new Singleplayer Game at level 1
	public void NewGame()
	{
		ProfileManager.GetInstance().GetProfile().SetCurrentLevelS(1);
		GameManager.levelIndex = 1;
		GameManager.singleplayer = true;
		SceneManager.LoadScene("Game");
	}

	///Continues at current Singleplayer level
	public void Continue()
	{
		GameManager.levelIndex = ProfileManager.GetInstance().GetProfile().GetCurrentLevelS();
		GameObject ressource = Resources.Load<GameObject>("Prefabs/Level/LevelS" + GameManager.levelIndex);
		if (ressource == null)
		{
			GameManager.levelIndex = 1;
		}
		GameManager.singleplayer = true;
		SceneManager.LoadScene("Game");
	}

	///Shows View to select which level to play
	public void LevelSelect()
    {
		GameManager.singleplayer = true;
		TransitionToLevelSelect();
	}
}
