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
		Debug.Log(ProfileManager.GetInstance().GetProfile(ProfileManager.GetInstance().GetProfileID()).ToString());
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
