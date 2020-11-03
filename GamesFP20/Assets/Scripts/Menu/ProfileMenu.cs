using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
///  This class is a child of MenuView and represents the Menu which is used for selecting Profiles.
/// </summary>
public class ProfileMenu : MenuView
{
	public Transform content;
	public GameObject profileSelectListItemPrefab;

	///Will be called from the AddProfile button
	public void AddProfile()
	{
		ProfileManager.GetInstance().AddProfile();
		Show();
	}

	///Override of the Standard Show method
	///First cleares the view, then loads LevelSelectItems for the level
	public override void Show()
    {
		ResetUI();
		LoadProfileSelectItems();
		gameObject.SetActive(true);
    }

	///Cleares the view, if there is already some content from earlier call
	private  void ResetUI()
	{
		for (int i = 0; i < content.transform.childCount; i++)
		{
			Destroy(content.transform.GetChild(i).gameObject);
		}
	}

	/// For every current profile, show one ProfileSelectItem with a button to use and to edit this profile
	private void LoadProfileSelectItems()
    {
		for (int i = 0; i < ProfileManager.GetInstance().GetProfileCount(); i++)
		{
			var selector = Instantiate(profileSelectListItemPrefab, content);
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
					Show();
				});
		}
	}
}
