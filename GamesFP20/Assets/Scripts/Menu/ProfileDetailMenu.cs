﻿using System.Collections;
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
        ProfileManager.GetInstance().GetProfile(currentProfile).SetVolume((int)(transform.GetComponentInChildren<Slider>().value));
    }

    public void ChangeName(string name)
    {
        ProfileManager.GetInstance().GetProfile(currentProfile).SetName(transform.GetComponentInChildren<InputField>().text);
    }

    public void ChangeAutoRespawn(bool respawn)
    {
        ProfileManager.GetInstance().GetProfile(currentProfile).SetAutoRespawn(transform.GetComponentInChildren<Toggle>().isOn);
    }

    public override void Show()
    {
        transform.Find("ProfileName").GetChild(0).GetComponent<InputField>().text = "" + ProfileManager.GetInstance().GetProfile(currentProfile).GetName();
        transform.Find("MaxLevel").GetChild(0).GetComponent<Text>().text = "" + ProfileManager.GetInstance().GetProfile(currentProfile).GetMaxLevel();
        transform.Find("CurrentLevel").GetChild(0).GetComponent<Text>().text = "" + ProfileManager.GetInstance().GetProfile(currentProfile).GetCurrentLevel();
        transform.Find("Volume").GetChild(1).GetComponent<Slider>().value = ProfileManager.GetInstance().GetProfile(currentProfile).GetVolume();
        transform.Find("AutoRespawn").GetChild(0).GetComponent<Toggle>().isOn = ProfileManager.GetInstance().GetProfile(currentProfile).GetAutoRespawn();
        transform.Find("DeleteProfile").gameObject.SetActive(ProfileManager.GetInstance().GetProfileCount() != 1);
        gameObject.SetActive(true);
    }
}
