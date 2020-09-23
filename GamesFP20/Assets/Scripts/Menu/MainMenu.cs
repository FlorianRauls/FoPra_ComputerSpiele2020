using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MenuView
{ 
	public void ExitGame()
	{
		Application.Quit();
	}

	public void NewGame()
	{
		ProfileManager.GetInstance().GetProfile().SetCurrentLevel(1);
		SceneManager.LoadScene("Game");
	}

	public void Continue()
	{
		LevelLoader.levelIndex = ProfileManager.GetInstance().GetProfile().GetCurrentLevel();
		SceneManager.LoadScene("Game");
	}
}
