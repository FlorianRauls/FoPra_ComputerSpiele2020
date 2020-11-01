using UnityEngine;
/// <summary>
///  This class is a child of MenuView and represents the Menu which is used for handling Starting a New Game, going to the Profile Settings or Quitting the game.
/// </summary>
public class MainMenu : MenuView
{	
	/// Closes the Game
	public void ExitGame()
	{
		Application.Quit();
	}
}
