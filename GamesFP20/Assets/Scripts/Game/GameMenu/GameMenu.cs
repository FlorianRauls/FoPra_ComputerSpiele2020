using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MenuView
{
	//Goes back to Menu Scene
	public void GoToMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}

	//Restarts Game Scene
	public void RestartLevel()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Game");
	}

	//Closes Menu and continues game
	public void Back()
	{
		GameManager.GetInstance().SetPlayerInMenu(false);
		MenuManager.GetInstance().Back();
	}

	//Override of the Standard Show method
	//Checks for the two checkboxes and sets the value if one of them exists -> Not quite necessary, because the checkboxes are probably only shown when isOn = false
	public override void Show()
    {
		Transform autoContinue = transform.Find("AutoContinue");
		if(autoContinue != null)
        {
			autoContinue.GetComponentInChildren<Toggle>().isOn = ProfileManager.GetInstance().GetProfile(ProfileManager.GetInstance().GetProfileID()).GetAutoContinue();
		}
		Transform autoRespawn = transform.Find("AutoRespawn");
		if (autoRespawn != null)
		{
			autoRespawn.GetComponentInChildren<Toggle>().isOn = ProfileManager.GetInstance().GetProfile(ProfileManager.GetInstance().GetProfileID()).GetAutoRespawn();
		}
		gameObject.SetActive(true);
	}

	//Updates the AutoRespawn Value -> Will be called when checking the checkbox -> Parameter is Hardcoded by Unity, so it will not be used, instead the value is taken explicitly
	public void ChangeAutoRespawn(bool respawn)
	{
		int currentProfile = ProfileManager.GetInstance().GetProfileID();
		ProfileManager.GetInstance().GetProfile(currentProfile).SetAutoRespawn(transform.GetComponentInChildren<Toggle>().isOn);
	}

	//Updates the AutoContinue Value -> Will be called when checking the checkbox -> Parameter is Hardcoded by Unity, so it will not be used, instead the value is taken explicitly
	public void ChangeAutoContinue(bool respawn)
	{
		int currentProfile = ProfileManager.GetInstance().GetProfileID();
		ProfileManager.GetInstance().GetProfile(currentProfile).SetAutoContinue(transform.GetComponentInChildren<Toggle>().isOn);
	}
}
