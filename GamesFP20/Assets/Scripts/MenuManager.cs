using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager singleton;
    public MenuView[] views = new MenuView[0];
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

    public static void ClearInstance()
    {
        singleton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/Menu")).GetComponent<MenuManager>();
        singleton.Start();
    }

    public void Initial()
    {
        //foreach(MenuView view in views)
        //{
        //    view.Hide();
        //}
        if(views.Length > 0)
        {
            Show(views[0]);
        }
    }
    public void Show(MenuEnum menu)
    {
        MenuView viewToCall = null;
        Debug.Log(views.Length);
        foreach (MenuView view in views)
        {
            if (view.menuType == menu)
            {
                viewToCall = view;
            }
        }
        if (viewToCall == null)
        {
            Debug.Log("Could not find Menu Enum");
        }
        else
        {
            Show(viewToCall);
        }
    }

    public void Show(MenuView view)
    {
        viewStack.Add(view);
        view.Show();
    }

    public void TransitionTo(MenuView view)
    {
        Debug.Log("Transition: " + view + " from: " + viewStack[viewStack.Count - 1]);
        viewStack[viewStack.Count-1].Hide();
        Show(view);
    }

    public void TransitionTo(int id)
    {
        TransitionTo(views[id]);
    }

    public void TransitionTo(MenuEnum menu)
    {
        MenuView viewToCall = null;
        foreach (MenuView view in views)
        {
            if (view.menuType == menu)
            {
                viewToCall = view;
            }
        }
        if(viewToCall == null)
        {
            Debug.Log("Could not find Menu Enum");
        }
        else
        {
            TransitionTo(viewToCall);
        }
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
