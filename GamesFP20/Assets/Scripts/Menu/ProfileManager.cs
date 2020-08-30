using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
    private static ProfileManager singleton;
    private int profileId;
    private Profile[] profiles;

    void Start()
    {
        LoadProfile();
    }

    public void LoadProfiles()
    {

    }

    public void SaveProfiles()
    {

    }

    public Profile CreateProfile()
    {

    }

    public Profile GetProfile()
    {
        
    }

    public static GetInstance()
    {
        return singleton;
    }
}