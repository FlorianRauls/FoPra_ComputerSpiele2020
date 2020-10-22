using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Profile
{
    private int id = 0;
    private string name = "Player";
    private int volume = 100;
    private int currentLevelS = 1;//S for Singleplayer
    private int maxLevelS = 1;
    private int currentLevelM = 1;//M for Multiplayer
    private int maxLevelM = 1;
    private bool autoRespawn = false;
    private bool autoContinue = false;

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

    public int GetCurrentLevelS()
    {
        return currentLevelS;
    }

    public void SetCurrentLevelS(int level)
    {
        this.currentLevelS = level;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public int GetMaxLevelS()
    {
        return maxLevelS;
    }

    public void SetMaxLevelS(int level)
    {
        this.maxLevelS = level;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public int GetCurrentLevelM()
    {
        return currentLevelM;
    }

    public void SetCurrentLevelM(int level)
    {
        this.currentLevelM = level;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public int GetMaxLevelM()
    {
        return maxLevelM;
    }

    public void SetMaxLevelM(int level)
    {
        this.maxLevelM = level;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public bool GetAutoRespawn()
    {
        return autoRespawn;
    }

    public void SetAutoContinue(bool autoContinue)
    {
        this.autoContinue = autoContinue;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public bool GetAutoContinue()
    {
        return autoContinue;
    }

    public void SetAutoRespawn(bool respawn)
    {
        this.autoRespawn = respawn;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public string ToString()
    {
        string output = "{id:" + id + ",name:" + name + ",volume:" + volume + ",currentLevelS:" + currentLevelS + ",maxLevelS:" + maxLevelS + ",currentLevelM:" + currentLevelM + ",maxLevelM:" + maxLevelM + ",autoRespawn:" + autoRespawn + ",autoContinue:" + autoContinue + "}";
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

        rx = new Regex(@"currentLevelS:(?<currentLevelS>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        profile.currentLevelS = int.Parse(rx.Matches(input)[0].Groups["currentLevelS"].Value);

        rx = new Regex(@"maxLevelS:(?<maxLevelS>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        profile.maxLevelS = int.Parse(rx.Matches(input)[0].Groups["maxLevelS"].Value);

        rx = new Regex(@"currentLevelM:(?<currentLevelM>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        profile.currentLevelM = int.Parse(rx.Matches(input)[0].Groups["currentLevelM"].Value);

        rx = new Regex(@"maxLevelM:(?<maxLevelM>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        profile.maxLevelM = int.Parse(rx.Matches(input)[0].Groups["maxLevelM"].Value);

        rx = new Regex(@"autoRespawn:(?<autoRespawn>\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        profile.autoRespawn = bool.Parse(rx.Matches(input)[0].Groups["autoRespawn"].Value);

        rx = new Regex(@"autoContinue:(?<autoContinue>\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        profile.autoContinue = bool.Parse(rx.Matches(input)[0].Groups["autoContinue"].Value);

        return profile;
    }
}
