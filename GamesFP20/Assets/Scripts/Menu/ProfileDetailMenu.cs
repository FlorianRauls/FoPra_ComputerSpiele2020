using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileDetailMenu : MenuView
{
    MenuEnum menuType = MenuEnum.ProfileDetail;

    public void DeleteProfile()
    {
        int currentProfile = ProfileManager.GetInstance().GetProfileID();
        ProfileManager.GetInstance().DeleteProfile(currentProfile);
        Back();
    }

    public void ChangeVolume(int volume)
    {
        int currentProfile = ProfileManager.GetInstance().GetProfileID();
        ProfileManager.GetInstance().GetProfile(currentProfile).SetVolume((int)(transform.GetComponentInChildren<Slider>().value));
    }

    public void ChangeName(string name)
    {
        int currentProfile = ProfileManager.GetInstance().GetProfileID();
        ProfileManager.GetInstance().GetProfile(currentProfile).SetName(transform.GetComponentInChildren<InputField>().text);
    }

    public void ChangeAutoRespawn(bool respawn)
    {
        int currentProfile = ProfileManager.GetInstance().GetProfileID();
        ProfileManager.GetInstance().GetProfile(currentProfile).SetAutoRespawn(transform.Find("AutoRespawn").GetComponentInChildren<Toggle>().isOn);
    }

    public void ChangeAutoContinue(bool respawn)
    {
        int currentProfile = ProfileManager.GetInstance().GetProfileID();
        ProfileManager.GetInstance().GetProfile(currentProfile).SetAutoContinue(transform.Find("AutoContinue").GetComponentInChildren<Toggle>().isOn);
    }

    public override void Show()
    {
        int currentProfile = ProfileManager.GetInstance().GetProfileID();
        transform.Find("ProfileName").GetChild(0).GetComponent<InputField>().text = "" + ProfileManager.GetInstance().GetProfile(currentProfile).GetName();
        transform.Find("MaxLevel").GetChild(0).GetComponent<Text>().text = "" + ProfileManager.GetInstance().GetProfile(currentProfile).GetMaxLevelS();
        transform.Find("CurrentLevel").GetChild(0).GetComponent<Text>().text = "" + ProfileManager.GetInstance().GetProfile(currentProfile).GetCurrentLevelS();
        transform.Find("MaxLevel").GetChild(1).GetComponent<Text>().text = "" + ProfileManager.GetInstance().GetProfile(currentProfile).GetMaxLevelM();
        transform.Find("CurrentLevel").GetChild(1).GetComponent<Text>().text = "" + ProfileManager.GetInstance().GetProfile(currentProfile).GetCurrentLevelM();
        transform.Find("Volume").GetChild(1).GetComponent<Slider>().value = ProfileManager.GetInstance().GetProfile(currentProfile).GetVolume();
        transform.Find("AutoRespawn").GetChild(0).GetComponent<Toggle>().isOn = ProfileManager.GetInstance().GetProfile(currentProfile).GetAutoRespawn();
        transform.Find("DeleteProfile").gameObject.SetActive(ProfileManager.GetInstance().GetProfileCount() != 1);
        gameObject.SetActive(true);
    }
}
