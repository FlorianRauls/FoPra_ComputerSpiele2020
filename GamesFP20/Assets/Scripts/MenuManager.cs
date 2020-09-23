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

    }

    public static MenuManager GetInstance()
    {
        return singleton;
    }

    public void TransitionTo(int id)
    {

    }

    public void Back()
    {

    }

    public List<MenuView> GetViewStack()
    {
        return viewStack;
    }
}
