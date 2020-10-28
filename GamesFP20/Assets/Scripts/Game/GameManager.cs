using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Current Level
    public static int levelIndex = 1;

    // Check whether or not we are playing singleplayer
    public static bool singleplayer = true;
    private GameObject boy;
    private GameObject dog;
    private int levelStart = 0;
    private GameObject level;
    private GameObject levelDivider;
    private static GameManager singleton;

    // Start is called before the first frame update
    public void Start()
    {
        singleton = this;
        // On Level start we load the Player
        boy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        if (!singleplayer)
        {
            dog = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Dog"));
        }
        // And Load the first Level
        GameObject levelBegin = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Level/Level-"));
        LoadLevel();
        LoadLevelDivider();
    }

    // Update is called once per frame
    void Update()
    {
        //Clicking on Escape opens Pause Menu
        if(Input.GetButtonDown("Pause")){
            ShowPauseMenu();
        }

        // This is our wincondidtion
        if (boy.transform.position.x > levelStart + level.GetComponent<Level>().width)
        {
            LoadNextLevel();
        }

        // This is an alternative win condition in multiplayer
        if (dog != null && dog.transform.position.x > levelStart + level.GetComponent<Level>().width)
        {
            LoadNextLevel();
        }

        // This is a loos condition in multiplayer
        if (dog != null && Math.Abs(dog.transform.position.x- boy.transform.position.x) > 10)
        {
            dog.GetComponent<Player>().defeat();
        }
    }

    // Load the next level
    public void LoadNextLevel()
    {
        IncreaseLevel();
        UpdateProfile();
        ShowLevelFinishMenu();
        LoadLevel();
        LoadLevelDivider();
    }

    // Check whether or not this is singleplayer
    // Write into the Profile that we finished the level
    private void UpdateProfile()
    {
        if (singleplayer)
        {
            if (levelIndex > ProfileManager.GetInstance().GetProfile().GetMaxLevelS())
            {
                ProfileManager.GetInstance().GetProfile().SetMaxLevelS(levelIndex);
            }
            ProfileManager.GetInstance().GetProfile().SetCurrentLevelS(levelIndex);
        }
        else
        {
            if (levelIndex > ProfileManager.GetInstance().GetProfile().GetMaxLevelM())
            {
                ProfileManager.GetInstance().GetProfile().SetMaxLevelM(levelIndex);
            }
            ProfileManager.GetInstance().GetProfile().SetCurrentLevelM(levelIndex);
        }
    }

    // Locally increase the level index for loading of next level
    void IncreaseLevel()
    {
        levelIndex++;
        levelStart += level.GetComponent<Level>().width + levelDivider.GetComponent<Level>().width;
        
    }

    void LoadLevelDivider()
    {
        levelDivider = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Level/Level0"));
        levelDivider.transform.position = new Vector3(levelDivider.transform.position.x + level.GetComponent<Level>().width, levelDivider.transform.position.y, levelDivider.transform.position.z);
    }

    void LoadLevel()
    {
        if (singleplayer)
        {
            level = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Level/LevelS" + levelIndex));
        }
        else
        {
            level = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Level/LevelM" + levelIndex));
        }
        
        level.transform.position = new Vector3(level.transform.position.x + levelStart, level.transform.position.y, level.transform.position.z);
    }

    public Level GetCurrentLevel()
    {
        return level.GetComponent<Level>();
    }

    public Level GetCurrentDividerLevel()
    {
        return levelDivider.GetComponent<Level>();
    }

    public static GameManager GetInstance()
    {
        return singleton;
    }

    public static void ClearInstance()
    {
        singleton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager")).GetComponent<GameManager>();
        singleton.Start();
    }

    public void PlayerDefeated()
    {
        ShowDeathMenu();
    }

    private void ShowDeathMenu()
    {
        if (!ProfileManager.GetInstance().GetProfile().GetAutoRespawn())
        {
            MenuManager.GetInstance().Show(MenuEnum.GameDeath);
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void ShowLevelFinishMenu()
    {
        if (!ProfileManager.GetInstance().GetProfile().GetAutoContinue())
        {
            MenuManager.GetInstance().Show(MenuEnum.GameFinish);
        }
    }

    private void ShowPauseMenu()
    {
        MenuManager.GetInstance().Show(MenuEnum.GamePause);
    }
}