using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private static MenuManager singleton;
    public MenuView[] views = new MenuView[0];
    private List<MenuView> viewStack = new List<MenuView>();

    public void Start()
    {
        MenuManager.singleton = this;
        MenuManager.GetInstance().Show(MenuEnum.Main);
    }

    //Used to get the Instance of the MenuManager
    public static MenuManager GetInstance()
    {
        return singleton;
    }

    //Only used for Tests to have a clear Instance for every single test
    public static void ClearInstance()
    {
        singleton = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/Menu")).GetComponent<MenuManager>();
        singleton.Start();
    }

    //Shows the next View selected by viewEnum -> Can be possible, that the enum does not exist
    public void Show(MenuEnum menu)
    {
        Show(ViewByEnum(menu));
    }

    //Shows a new View Object
    //Only public for Tests
    public void Show(MenuView view)
    {
        if (view != null)
        {
            viewStack.Add(view);
            view.Show();
        }
    }

    //Shows a new View Object and hides the current one
    private void TransitionTo(MenuView view)
    {
        viewStack[viewStack.Count-1].Hide();
        Show(view);
    }

    //Shows the next View selected by viewEnum and hides the current one -> Can be possible, that the enum does not exist
    public void TransitionTo(MenuEnum menu)
    {
        TransitionTo(ViewByEnum(menu));
    }

    //Gets the View Object from View Enum -> Can be possible, that the enum does not exist
    private MenuView ViewByEnum(MenuEnum menu)
    {
        MenuView viewToCall = null;
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
        return viewToCall;
    }

    //Hides the current View and Shows the last one fromn the stack
    public void Back()
    {
        viewStack[viewStack.Count-1].Hide();
        viewStack.RemoveAt(viewStack.Count-1);
        if (viewStack.Count > 0)
        {
            viewStack[viewStack.Count - 1].Show();
        }
    }

    //Only used for Testing
    public List<MenuView> GetViewStack()
    {
        return viewStack;
    }
}
