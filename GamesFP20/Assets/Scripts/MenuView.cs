using System;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    public virtual void TransitionTo(int id)
    {
        MenuManager.GetInstance().TransitionTo(id);
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
