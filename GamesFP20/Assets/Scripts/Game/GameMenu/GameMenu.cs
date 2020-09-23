using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MenuView
{
	public void GoToMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene("Game");
	}

	public void Continue()
	{
		Hide();
	}
}
