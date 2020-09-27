using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileMenu : MenuView
{
	MenuEnum menuType = MenuEnum.ProfileSelect;
	public GameObject content;
	public GameObject profileSelectListItemPrefab;

	public void AddProfile()
	{
		ProfileManager.GetInstance().AddProfile();
		ResetUI();
	}

	public override void Show()
    {
		LoadProfileSelectItems();
		gameObject.SetActive(true);
    }

	public void ResetUI()
	{
		for (int i = 0; i < content.transform.childCount; i++)
		{
			Destroy(content.transform.GetChild(i).gameObject);
		}
		Show();
	}

	void LoadProfileSelectItems()
    {
		for (int i = 0; i < ProfileManager.GetInstance().GetProfileCount(); i++)
		{
			var selector = Instantiate(profileSelectListItemPrefab, content.transform);
			selector.transform.localPosition = new Vector3(0, -40 - i * 50, 0);
			selector.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + ProfileManager.GetInstance().GetProfile(i).GetName();

			if (i == ProfileManager.GetInstance().GetProfileID())
			{
				selector.transform.GetChild(0).GetComponent<Image>().color = UnityEngine.Color.green;
			}
			else
			{
				selector.transform.GetChild(0).GetComponent<Image>().color = UnityEngine.Color.yellow;
			}

			int profile = i;
			selector.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(
				() =>
				{
					ProfileManager.GetInstance().SetProfileID(profile);
					MenuManager.GetInstance().TransitionTo(MenuEnum.ProfileDetail);
				});


			selector.transform.GetChild(0).GetChild(2).GetComponent<Button>().onClick.AddListener(
				() =>
				{
					ProfileManager.GetInstance().SetProfileID(profile);
					ResetUI();
				});
		}
	}
}
