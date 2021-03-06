﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;
/// <summary>
///  This class is used for Loading and Saving Profiles.
/// </summary>
public class ProfileManager : MonoBehaviour
{
    private static ProfileManager singleton;
    private int profileID = 0;
    private int maxID = 0;
    private Profile[] profiles = new Profile[0];
    private const string path = "profiles.txt";

    ///Creates instance and loads profiles
    public void Start()
    {
        ProfileManager.singleton = this;
        LoadProfiles();
    }

    ///Returns instance if there is one, otherwise create one
    public static ProfileManager GetInstance()
    {
        if (singleton == null)
        {
            singleton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>();
            singleton.Start();
        }
        return singleton;

    }

    ///Cleares the instance -> only used for testing
    public static void ClearInstance()
    {
        singleton = null;
    }

    ///Clears all current profiles -> needed to have clear profiles for testing
    public void ClearProfiles()
    {
        maxID = -1;
        profiles = new Profile[0];
        AddProfile();
        SaveProfiles();
    }

    ///Loads profiles from a file
    public void LoadProfiles()
    {
        if (System.IO.File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            string input = reader.ReadToEnd();
            reader.Close();

            Regex rx = new Regex(@"profileID:(?<id>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            profileID = int.Parse(rx.Matches(input)[0].Groups["id"].Value);


            rx = new Regex(@"maxID:(?<id>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            maxID = int.Parse(rx.Matches(input)[0].Groups["id"].Value);

            rx = new Regex(@"profiles:\[(?<profiles>[^\]]+)\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            input = rx.Matches(input)[0].Groups["profiles"].Value;

            rx = new Regex(@"({(?<profile>[^}]*)})+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(input);
            profiles = new Profile[matches.Count];
            int i = 0;
            foreach (Match match in matches)
            {
                profiles[i] = Profile.FromString(match.Groups["profile"].Value);
                i++;
            }
        }
        else
        {
            AddProfile();
        }
    }

    ///Saves profiles to a file
    public void SaveProfiles()
    {
        string output = "{profileID:" + profileID + ",maxID:" + maxID + ",profiles:[";
        for(int i = 0; i < profiles.Length; i++)
        {
            output += profiles[i].ToString();
            if(i < profiles.Length - 1)
            {
                output += ",";
            }
        }
        output += "]}";
        File.WriteAllText(path, output);
    }

    ///Adds a profile
    public void AddProfile()
    {
        profileID = profiles.Length;
        Profile[] profileCopy = profiles;
        profiles = new Profile[profileCopy.Length + 1];
        for (int i = 0; i < profileCopy.Length; i++)
        {
            profiles[i] = profileCopy[i];
        }
        profiles[profileCopy.Length] = new Profile(++maxID);
        ProfileManager.GetInstance().SaveProfiles();
    }

    ///Gets the current profile -> If there is none, create a new one
    public Profile GetProfile()
    {
        if(profiles.Length == 0)
        {
            AddProfile();
        }
        return profiles[profileID];
    }

    ///Deletes the current profile and moves the profiles in the profile list if necessary
    public void DeleteProfile(int id)
    {
        if (id == profileID)
        {
            profileID = 0;
        }
        else
        {
            if (id < profileID)
            {
                profileID--;
            }
        }
        Profile[] profileCopy = profiles;
        profiles = new Profile[profileCopy.Length - 1];
        int profileDeleted = 0;
        for (int i = 0; i < profileCopy.Length; i++)
        {
            if (i == id)
            {
                profileDeleted = 1;
            }
            else
            {
                profiles[i - profileDeleted] = profileCopy[i];
            }
        }

        ProfileManager.GetInstance().SaveProfiles();
    }

    ///Getter and Setter
    public int GetProfileID()
    {
        return profileID;
    }

    public void SetProfileID(int id)
    {
        profileID = id;
        ProfileManager.GetInstance().SaveProfiles();
    }

    public int GetProfileCount()
    {
        return profiles.Length;
    }

    public Profile GetProfile(int id)
    {
        return profiles[id];
    }

    public int GetMaxID()
    {
        return maxID;
    }
}
