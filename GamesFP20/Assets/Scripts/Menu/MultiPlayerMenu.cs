using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
///  This class is a child of MenuView and represents the Menu which is used for starting a Multiplayer Game
/// </summary>
public class MultiPlayerMenu : MenuView
{
	///Starts a new Multiplayer Game at level 1
	public void NewGame()
	{
		ProfileManager.GetInstance().GetProfile().SetCurrentLevelM(1);
		GameManager.levelIndex = 1;
		GameManager.singleplayer = false;
		SceneManager.LoadScene("Game");
	}

	///Continues at current Multiplayer level
	public void Continue()
	{
		GameManager.levelIndex = ProfileManager.GetInstance().GetProfile().GetCurrentLevelM();
		GameObject ressource = Resources.Load<GameObject>("Prefabs/Level/LevelM" + GameManager.levelIndex);
		if(ressource == null)
        {
			GameManager.levelIndex = 1;
		}
		GameManager.singleplayer = false;
		SceneManager.LoadScene("Game");
	}

	///Shows View to select which level to play
	public void LevelSelect()
	{
		GameManager.singleplayer = false;
		TransitionToLevelSelect();
	}
}
