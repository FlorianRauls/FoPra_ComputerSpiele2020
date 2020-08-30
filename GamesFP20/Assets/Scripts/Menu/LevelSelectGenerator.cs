using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectGenerator : MonoBehaviour
{
	public GameObject content;
	public GameObject levelSelectorPrefab;

	void Start()
	{
		var rect = GetComponent<RectTransform>();

		for (int i = 1; Resources.Load<GameObject>($"Prefabs/Level/Level{i}") != null; i++)
		{
			var selector = Instantiate(levelSelectorPrefab, content.transform);
			selector.transform.localPosition = new Vector3(0, -40 - i * 50, 0);
			selector.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Level " + i;

			int level = i;
			selector.GetComponentInChildren<Button>().onClick.AddListener(
				() =>
				{
					LevelLoader.levelIndex = level;
					SceneManager.LoadScene("Game");
				});
		}
	}
}
