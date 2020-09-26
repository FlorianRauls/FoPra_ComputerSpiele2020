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
}
