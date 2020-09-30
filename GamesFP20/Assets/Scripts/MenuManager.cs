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
        if (singleton == null)
        {
            singleton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/Menu")).GetComponent<MenuManager>();
            singleton.Start();
        }
        return singleton;
    }

    public static void ClearInstance()
    {
        singleton = null;
    }

    public void Initial()
    {
        foreach(MenuView view in views)
        {
            view.Hide();
        }
        if(views.Length > 0)
        {
            Show(views[0]);
        }
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

    public void TransitionTo(MenuEnum menu)
    {
        foreach (MenuView view in views)
        {
            if (view.menuType == menu)
            {
                TransitionTo(view);
            }
            else
            {
                Debug.Log("Could not find Menu Enum");
            }
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
