using UnityEngine;

public class MainMenu : MenuView
{
	public void Start()
    {
		MenuManager.GetInstance().Show(this);
    }
	
	MenuEnum menuType = MenuEnum.Main;
	public void ExitGame()
	{
		Application.Quit();
	}
}
