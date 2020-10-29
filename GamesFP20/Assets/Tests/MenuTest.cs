using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MenuTest
    {
        [Test]
        public void MenuManagerTest()
        {
            MenuManager.ClearInstance();
            MenuManager manager = MenuManager.GetInstance();
            manager.views = new MenuView[1];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/DummyMenuView")).GetComponent<MenuView>();
            manager.Start();
            manager.Show(manager.views[0]);
            Assert.IsTrue(manager.GetViewStack()[0] == manager.views[0]);
            Assert.IsTrue(manager.GetViewStack()[0].gameObject.activeSelf == true);
        }
        [Test]
        public void MenuViewTest()
        {
            MenuManager.ClearInstance();
            MenuManager manager = MenuManager.GetInstance();
            manager.views = new MenuView[3];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/DummyMenuView")).GetComponent<MenuView>();
            manager.views[1] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/DummyMenuView")).GetComponent<MenuView>();
            manager.views[2] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/DummyMenuView")).GetComponent<MenuView>();
            manager.Start();
            manager.Show(manager.views[0]);
            manager.GetViewStack()[manager.GetViewStack().Count-1].TransitionTo(MenuEnum.Dummy);
            Assert.IsTrue(manager.GetViewStack()[manager.GetViewStack().Count - 1].gameObject.activeSelf == true);
            MenuManager.GetInstance().TransitionTo(2);
            Assert.IsTrue(manager.GetViewStack()[manager.GetViewStack().Count - 1].gameObject.activeSelf == true);
            manager.GetViewStack()[manager.GetViewStack().Count - 1].Back();
            Assert.IsTrue(manager.GetViewStack()[manager.GetViewStack().Count - 1].gameObject.activeSelf == true);
        }
        [Test]
        public void LevelSelectMenuTest()
        {
            MenuManager.ClearInstance();
            MenuManager manager = MenuManager.GetInstance();
            manager.views = new MenuView[1];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/LevelSelectMenu")).GetComponent<MenuView>();
            manager.Start();
            manager.Show(manager.views[0]);
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(LevelSelectMenu));
        }
        [Test]
        public void ProfileSelectMenuTest()
        {
            MenuManager.ClearInstance();
            MenuManager manager = MenuManager.GetInstance();
            manager.views = new MenuView[1];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/ProfileSelectMenu")).GetComponent<MenuView>();
            manager.Start();
            manager.Show(manager.views[0]);
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(ProfileMenu));
        }
        [Test]
        public void ProfileDetailMenuTest()
        {
            MenuManager.ClearInstance();
            MenuManager manager = MenuManager.GetInstance();
            manager.views = new MenuView[1];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/ProfileDetailMenu")).GetComponent<MenuView>();
            manager.Start();
            manager.Show(manager.views[0]);
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(ProfileDetailMenu));
        }
        [Test]
        public void SinglePlayerMenuTest()
        {
            MenuManager.ClearInstance();
            MenuManager manager = MenuManager.GetInstance();
            manager.views = new MenuView[1];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/SinglePlayer")).GetComponent<MenuView>();
            manager.Start();
            manager.Show(manager.views[0]);
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(SinglePlayerMenu));
        }
        [Test]
        public void MultiPlayerMenuTest()
        {
            MenuManager.ClearInstance();
            MenuManager manager = MenuManager.GetInstance();
            manager.views = new MenuView[1];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/MultiPlayer")).GetComponent<MenuView>();
            manager.Start();
            manager.Show(manager.views[0]);
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(MultiPlayerMenu));
        }
        [Test]
        public void GameMenuTest()
        {
            MenuManager.ClearInstance();
            MenuManager manager = MenuManager.GetInstance();
            ProfileManager.ClearInstance();
            ProfileManager.GetInstance();
            manager.views = new MenuView[3];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/PauseMenu")).GetComponent<MenuView>();
            manager.views[1] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/DeathMenu")).GetComponent<MenuView>();
            manager.views[2] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/LevelFinishMenu")).GetComponent<MenuView>();
            manager.Start();
            manager.Show(manager.views[0]);
            Debug.Log(manager.GetViewStack().Count);
            manager.GetViewStack()[manager.GetViewStack().Count - 1].TransitionTo(MenuEnum.GameDeath);
            Debug.Log(manager.GetViewStack().Count);
            manager.GetViewStack()[manager.GetViewStack().Count - 1].TransitionTo(MenuEnum.GameFinish);
            Debug.Log(manager.GetViewStack().Count);
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(GameMenu));
            Assert.IsTrue(manager.GetViewStack()[1].GetType() == typeof(GameMenu));
            Assert.IsTrue(manager.GetViewStack()[2].GetType() == typeof(GameMenu));
        }
    }
}
