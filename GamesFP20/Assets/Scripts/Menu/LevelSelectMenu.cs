using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
///  This class is a child of MenuView and represents the Menu which is used for selecting Menus.
/// </summary>
public class LevelSelectMenu : MenuView
{
    public Transform content;
    public GameObject levelSelectListItemPrefab;

    //Override of the Standard Show method
    //First cleares the view, then loads LevelSelectItems for the level
    public override void Show()
    {
        ResetUI();
        LoadLevelSelectItems();
        gameObject.SetActive(true);
    }

    //Cleares the view, if there is already some content from earlier call
    private void ResetUI()
    {
        for (int i = 0; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }
    }

    // For every playable level, show one LevelSelectItem with a button to start this level
    private void LoadLevelSelectItems()
    {
        for (int i = 1; Resources.Load<GameObject>("Prefabs/Level/Level"+(GameManager.singleplayer?"S":"M")+i) != null && ((GameManager.singleplayer && i <= ProfileManager.GetInstance().GetProfile().GetMaxLevelS()) || (!GameManager.singleplayer && i <= ProfileManager.GetInstance().GetProfile().GetMaxLevelM())); i++)
        {
            var selector = Instantiate(levelSelectListItemPrefab, content);
            selector.transform.localPosition = new Vector3(0, -40 - i * 50, 0);
            selector.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Level " + i;

            int level = i;
            selector.GetComponentInChildren<Button>().onClick.AddListener(
                () =>
                {
                    GameManager.levelIndex = level;
                    SceneManager.LoadScene("Game");
                });
        }
    }
}
