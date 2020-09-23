using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectMenu : MenuView
{
    public GameObject content;
    public GameObject levelSelectListItemPrefab; 
    
    public override void Show()
    {
        LoadLevelSelectItems();
        gameObject.SetActive(true);
    }

    void LoadLevelSelectItems()
    {
        for (int i = 1; Resources.Load<GameObject>($"Prefabs/Level/Level{i}") != null; i++)
        {
            var selector = Instantiate(levelSelectListItemPrefab, content.transform);
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
