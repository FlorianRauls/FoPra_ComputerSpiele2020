using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
