using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{ 
	public void ExitGame()
	{
		Application.Quit();
	}

	public void NewGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void Continue()
	{
		LevelLoader.levelIndex = ProfileManager.GetInstance().GetProfile().GetCurrentLevel();
		SceneManager.LoadScene("Game");
	}
}
