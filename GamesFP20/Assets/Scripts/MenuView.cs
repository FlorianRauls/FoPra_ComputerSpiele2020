using System;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    public MenuEnum menuType = MenuEnum.Dummy;
    public virtual void TransitionTo(MenuEnum menu)
    {
        MenuManager.GetInstance().TransitionTo(menu);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Back()
    {
        MenuManager.GetInstance().Back();
    }

    //Following functions are only workarounds, because Unity does not allow functions with Enum Parameters

    public void TransitionToDummy()
    {
        TransitionTo(MenuEnum.Dummy);
    }
    public void TransitionToMain()
    {
        TransitionTo(MenuEnum.Main);
    }
    public void TransitionToLevelSelect()
    {
        TransitionTo(MenuEnum.LevelSelect);
    }
    public void TransitionToProfileSelect()
    {
        TransitionTo(MenuEnum.ProfileSelect);
    }
    public void TransitionToProfileDetail()
    {
        TransitionTo(MenuEnum.ProfileDetail);
    }
    public void TransitionToGamePause()
    {
        TransitionTo(MenuEnum.GamePause);
    }
    public void TransitionToGameDeath()
    {
        TransitionTo(MenuEnum.GameDeath);
    }
    public void TransitionToGameFinish()
    {
        TransitionTo(MenuEnum.GameFinish);
    }
}
