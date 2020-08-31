using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileEditor : MonoBehaviour
{
    private int currentProfile;
    public ProfileSelectionGenerator selector;
    public void Show(int profileID)
    {
        currentProfile = profileID;
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = ""+ProfileManager.GetInstance().GetProfile(profileID).GetMaxLevel();
        transform.GetChild(3).GetChild(0).GetComponent<Text>().text = ""+ProfileManager.GetInstance().GetProfile(profileID).GetCurrentLevel();
        transform.GetChild(4).GetChild(1).GetComponent<Slider>().value = ProfileManager.GetInstance().GetProfile(profileID).GetVolume();
        transform.GetChild(5).GetChild(0).GetComponent<Toggle>().isOn = ProfileManager.GetInstance().GetProfile(profileID).GetAutoRespawn();
        transform.GetChild(6).gameObject.SetActive(ProfileManager.GetInstance().GetProfileCount() != 1);
        gameObject.SetActive(true);
    }

    public void ChangeVolume(int volume)
    {
        ProfileManager.GetInstance().GetProfile(currentProfile).SetVolume((int)(transform.GetChild(4).GetChild(1).GetComponent<Slider>().value));
    }

    public void ChangeAutoRespawn(bool respawn)
    {
        ProfileManager.GetInstance().GetProfile(currentProfile).SetAutoRespawn(transform.GetChild(5).GetChild(0).GetComponent<Toggle>().isOn);
    }

    public void DeleteProfile()
    {
        ProfileManager.GetInstance().DeleteProfile(currentProfile);
        gameObject.SetActive(false);
        selector.ResetUI();
    }
}
