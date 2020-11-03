using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles Loadling the Levels, handling Menu Events
/// Loading Profiles and Saving.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// This int indexes the current Level.
    public static int levelIndex = 1;

    /// Check whether or not we are playing singleplayer
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

    /// This method wraps all other methods needed to load the next level.
    public void LoadNextLevel()
    {
        IncreaseLevel();
        UpdateProfile();
        ShowLevelFinishMenu();
        LoadLevel();
        LoadLevelDivider();
    }

    /// Check whether or not this is singleplayer
    /// Write into the Profile that we finished the level
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
        levelDivider.transform.position = new Vector3(levelDivider.transform.position.x + level.GetComponent<Level>().width + levelStart, levelDivider.transform.position.y, levelDivider.transform.position.z);
    }

    void LoadLevel()
    {
        GameObject ressource;
        if (singleplayer)
        {
            ressource = Resources.Load<GameObject>("Prefabs/Level/LevelS" + levelIndex);
        }
        else
        {
            ressource = Resources.Load<GameObject>("Prefabs/Level/LevelM" + levelIndex);
        }
        if (ressource == null)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            level = MonoBehaviour.Instantiate(ressource);
            level.transform.position = new Vector3(level.transform.position.x + levelStart, level.transform.position.y, level.transform.position.z);
        }
    }

    ///Getter
    public Level GetCurrentLevel()
    {
        return level.GetComponent<Level>();
    }
    ///Getter
    public Level GetCurrentDividerLevel()
    {
        return levelDivider.GetComponent<Level>();
    }
    ///Getter
    public static GameManager GetInstance()
    {
        return singleton;
    }
    /// This method reloads the current GameManager instance.
    public static void ClearInstance()
    {
        singleton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager")).GetComponent<GameManager>();
        singleton.Start();
    }
    /// Wraps all methods which trigger, if the player should die.
    public void PlayerDefeated()
    {
        ShowDeathMenu();
    }
    /// Handles opening the DeathMenu
    private void ShowDeathMenu()
    {
        if (!ProfileManager.GetInstance().GetProfile().GetAutoRespawn())
        {
            MenuManager.GetInstance().Show(MenuEnum.GameDeath);
            SetPlayerInMenu(true);
        }
        else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Game");
        }
    }

    private void ShowLevelFinishMenu()
    {
        if (!ProfileManager.GetInstance().GetProfile().GetAutoContinue())
        {
            MenuManager.GetInstance().Show(MenuEnum.GameFinish);
            SetPlayerInMenu(true);
        }
    }

    private void ShowPauseMenu()
    {
        MenuManager.GetInstance().Show(MenuEnum.GamePause);
        SetPlayerInMenu(true);
    }
    /// <summary>
    /// This is used by any menu to handle events happening
    /// when the Player opens up any menu.
    ///</summary>
    public void SetPlayerInMenu(bool newValue)
    {
        if (newValue)
        {
            Time.timeScale = 0;
        } 
        else
        {
            Time.timeScale = 1;
        }
        
        boy.GetComponent<Player>().setInMenu(newValue);
        if(dog != null)
        {
            dog.GetComponent<Player>().setInMenu(newValue);
        }
    }
}
