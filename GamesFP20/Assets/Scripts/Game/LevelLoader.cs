﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static int levelIndex = 1;
    private GameObject boy;
    private int levelStart = 0;
    private GameObject level;
    private GameObject levelDivider;

    // Start is called before the first frame update
    public void Start()
    {
        boy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        GameObject levelBegin = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Level/Level-"));

        LoadLevel();
        LoadLevelDivider();
    }

    // Update is called once per frame
    void Update()
    {
        if(boy.transform.position.x > levelStart + level.GetComponent<Level>().width)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        IncreaseLevel();

        if(levelIndex > ProfileManager.GetInstance().GetProfile().GetMaxLevel())
        {
            ProfileManager.GetInstance().GetProfile().SetMaxLevel(levelIndex);
        }
        ProfileManager.GetInstance().GetProfile().SetCurrentLevel(levelIndex);

        LoadLevel();
        LoadLevelDivider();
    }

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
        level = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Level/Level" + levelIndex));
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
}