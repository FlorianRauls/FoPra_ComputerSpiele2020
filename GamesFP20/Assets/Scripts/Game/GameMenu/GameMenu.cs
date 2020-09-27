using UnityEngine;
using UnityEngine.UI;
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

	public override void Show()
    {
		Transform autoContinue = transform.Find("AutoContinue");
		if(autoContinue != null)
        {
			autoContinue.GetComponent<Toggle>().isOn = ProfileManager.GetInstance().GetProfile(ProfileManager.GetInstance().GetProfileID()).GetAutoContinue();
		}
		Transform autoRespawn = transform.Find("AutoRespawn");
		if (autoRespawn != null)
		{
			autoRespawn.GetComponent<Toggle>().isOn = ProfileManager.GetInstance().GetProfile(ProfileManager.GetInstance().GetProfileID()).GetAutoRespawn();
		}
		gameObject.SetActive(true);
	}

	public void ChangeAutoRespawn(bool respawn)
	{
		int currentProfile = ProfileManager.GetInstance().GetProfileID();
		ProfileManager.GetInstance().GetProfile(currentProfile).SetAutoRespawn(transform.GetComponentInChildren<Toggle>().isOn);
	}

	public void ChangeAutoContinue(bool respawn)
	{
		int currentProfile = ProfileManager.GetInstance().GetProfileID();
		ProfileManager.GetInstance().GetProfile(currentProfile).SetAutoRespawn(transform.GetComponentInChildren<Toggle>().isOn);
	}
}
