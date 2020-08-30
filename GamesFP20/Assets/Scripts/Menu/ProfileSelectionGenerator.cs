using UnityEngine;
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
			selector.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = ""+ProfileManager.GetInstance().GetProfile(i).GetID();
			selector.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ProfileManager.GetInstance().GetProfile(i).GetName();

			int level = i;
			selector.GetComponentInChildren<Button>().onClick.AddListener(
				() =>
				{
					transform.parent.parent.GetChild(3).gameObject.SetActive(true);
					transform.parent.gameObject.SetActive(false);
				});
		}
	}
}
