using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Profile
{
    private int id = 0;
    private string name = "Player";
    private int volume = 100;
    private int currentLevel = 1;
    private int maxLevel = 1;
    private bool autoRespawn = false;

    public Profile(int id)
    {
        this.id = id;
    }

    public int GetID()
    {
        return id;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public int GetVolume()
    {
        return volume;
    }

    public void SetVolume(int volume)
    {
        this.volume = volume;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SetCurrentLevel(int level)
    {
        this.currentLevel = level;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public int GetMaxLevel()
    {
        return maxLevel;
    }

    public void SetMaxLevel(int level)
    {
        this.maxLevel = level;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public bool GetAutoRespawn()
    {
        return autoRespawn;
    }

    public void SetAutoRespawn(bool respawn)
    {
        this.autoRespawn = respawn;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public string ToString()
    {
        string output = "{id:" + id + ",name:" + name + ",volume:" + volume + ",currentLevel:" + currentLevel + ",maxLevel:" + maxLevel + ",autoRespawn:" + autoRespawn + "}";
        return output;
    }

    public static Profile FromString(string input)
    {
        Debug.Log(input);
        Regex rx = new Regex(@"id:(?<id>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        Profile profile = new Profile(int.Parse(rx.Matches(input)[0].Groups["id"].Value));

        rx = new Regex(@"name:(?<name>\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        profile.name = rx.Matches(input)[0].Groups["name"].Value;

        rx = new Regex(@"volume:(?<volume>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        profile.volume = int.Parse(rx.Matches(input)[0].Groups["volume"].Value);

        rx = new Regex(@"currentLevel:(?<currentLevel>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        profile.currentLevel = int.Parse(rx.Matches(input)[0].Groups["currentLevel"].Value);

        rx = new Regex(@"maxLevel:(?<maxLevel>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        profile.maxLevel = int.Parse(rx.Matches(input)[0].Groups["maxLevel"].Value);

        rx = new Regex(@"autoRespawn:(?<autoRespawn>\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        profile.autoRespawn = bool.Parse(rx.Matches(input)[0].Groups["autoRespawn"].Value);

        return profile;
    }
}
