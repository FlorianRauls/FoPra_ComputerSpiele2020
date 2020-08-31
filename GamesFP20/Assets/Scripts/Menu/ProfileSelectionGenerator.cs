﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileSelectionGenerator : MonoBehaviour
{
	public GameObject content;
	public GameObject profileSelectorPrefab;

	void Start()
	{
		var rect = GetComponent<RectTransform>();

		for (int i = 0; i < ProfileManager.GetInstance().GetProfileCount(); i++)
		{
			var selector = Instantiate(profileSelectorPrefab, content.transform);
			selector.transform.localPosition = new Vector3(0, -40 - i * 50, 0);
			selector.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ""+ProfileManager.GetInstance().GetProfile(i).GetName();

			if(i == ProfileManager.GetInstance().GetProfileID())
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
					transform.parent.parent.GetChild(3).GetComponent<ProfileEditor>().Show(profile);
					transform.parent.gameObject.SetActive(false);
				});


			selector.transform.GetChild(0).GetChild(2).GetComponent<Button>().onClick.AddListener(
				() =>
				{
					ProfileManager.GetInstance().SetProfileID(profile);
					ResetUI();
				});
		}
	}

	public void AddProfile()
	{
		ProfileManager.GetInstance().AddProfile();
		ResetUI();
	}

	public void ResetUI()
    {
		for (int i = 0; i < content.transform.childCount; i++)
		{
			Destroy(content.transform.GetChild(i).gameObject);
		}
		Start();
	}
}
