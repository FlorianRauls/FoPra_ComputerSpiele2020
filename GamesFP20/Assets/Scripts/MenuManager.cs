using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager singleton;
    public MenuView[] views;
    List<MenuView> viewStack = new List<MenuView>();

    public void Start()
    {
        MenuManager.singleton = this;
        Initial();
    }

    public static MenuManager GetInstance()
    {
        return singleton;
    }

    public void Initial()
    {
        foreach(MenuView view in views)
        {
            view.Hide();
        }
        Show(views[0]);
    }

    public void Show(MenuView view)
    {
        viewStack.Add(view);
        view.Show();
    }

    public void TransitionTo(MenuView view)
    {
        viewStack[viewStack.Count-1].Hide();
        Show(view);
    }

    public void TransitionTo(int id)
    {
        TransitionTo(views[id]);
    }

    public void Back()
    {
        viewStack[viewStack.Count-1].Hide();
        viewStack.RemoveAt(viewStack.Count-1);
        viewStack[viewStack.Count-1].Show();
    }

    public List<MenuView> GetViewStack()
    {
        return viewStack;
    }
}
