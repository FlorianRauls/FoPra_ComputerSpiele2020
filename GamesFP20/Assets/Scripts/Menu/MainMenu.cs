using UnityEngine;

public class MainMenu : MenuView
{
	MenuEnum menuType = MenuEnum.Main;
	public void ExitGame()
	{
		Application.Quit();
	}
}
