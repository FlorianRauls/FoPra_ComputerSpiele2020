using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileDetailMenu : MenuView
{
    MenuEnum menuType = MenuEnum.ProfileDetail;
    private int currentProfile = ProfileManager.GetInstance().GetProfileID();

    public void DeleteProfile()
    {
        ProfileManager.GetInstance().DeleteProfile(currentProfile);
        Back();
    }

    public void ChangeVolume(int volume)
    {
        ProfileManager.GetInstance().GetProfile(currentProfile).SetVolume((int)(transform.GetChild(4).GetChild(1).GetComponent<Slider>().value));
    }

    public void ChangeAutoRespawn(bool respawn)
    {
        ProfileManager.GetInstance().GetProfile(currentProfile).SetAutoRespawn(transform.GetChild(5).GetChild(0).GetComponent<Toggle>().isOn);
    }

    public override void Show()
    {
        transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "" + ProfileManager.GetInstance().GetProfile(currentProfile).GetMaxLevel();
        transform.GetChild(3).GetChild(0).GetComponent<Text>().text = "" + ProfileManager.GetInstance().GetProfile(currentProfile).GetCurrentLevel();
        transform.GetChild(4).GetChild(1).GetComponent<Slider>().value = ProfileManager.GetInstance().GetProfile(currentProfile).GetVolume();
        transform.GetChild(5).GetChild(0).GetComponent<Toggle>().isOn = ProfileManager.GetInstance().GetProfile(currentProfile).GetAutoRespawn();
        transform.GetChild(6).gameObject.SetActive(ProfileManager.GetInstance().GetProfileCount() != 1);
        gameObject.SetActive(true);
    }
}
