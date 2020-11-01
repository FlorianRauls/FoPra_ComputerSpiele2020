using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  This class handles the Audio Volume.
/// </summary>
public class AudioManager : MonoBehaviour
{
    private static AudioManager singleton;
    void Start()
    {
        singleton = this;
        ChangeVolume();
    }

    public static AudioManager GetInstance()
    {
        return singleton;
    }

    public void ChangeVolume()
    {
        gameObject.GetComponent<AudioSource>().volume = ProfileManager.GetInstance().GetProfile().GetVolume()/100f;
    }
}
