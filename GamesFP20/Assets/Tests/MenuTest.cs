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
            MenuManager manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/Menu")).GetComponent<MenuManager>();
            manager.views = new MenuView[1];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/DummyMenuView")).GetComponent<MenuView>();
            manager.Start();
            Assert.IsTrue(manager.GetViewStack()[0] == manager.views[0]);
            Assert.IsTrue(manager.GetViewStack()[0].gameObject.activeSelf == true);
        }
        [Test]
        public void MenuViewTest()
        {
            MenuManager manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/Menu")).GetComponent<MenuManager>();
            manager.views = new MenuView[3];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/DeathMenu")).GetComponent<MenuView>();
            manager.views[1] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/DummyMenuView")).GetComponent<MenuView>();
            manager.views[2] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/PauseMenu")).GetComponent<MenuView>();
            manager.Start();
            Debug.Log(manager.GetViewStack()[0].gameObject.activeSelf);
            manager.GetViewStack()[manager.GetViewStack().Count-1].TransitionTo(MenuEnum.Dummy);
            Assert.IsTrue(manager.GetViewStack()[1].gameObject.activeSelf == true);
            MenuManager.GetInstance().TransitionTo(2);
            Assert.IsTrue(manager.GetViewStack()[2].gameObject.activeSelf == true);
            Assert.IsTrue(manager.GetViewStack().Count == 3);
            manager.GetViewStack()[manager.GetViewStack().Count - 1].Back();
            Assert.IsTrue(manager.GetViewStack()[1].gameObject.activeSelf == true);
            Assert.IsTrue(manager.GetViewStack().Count == 2);
        }
        [Test]
        public void LevelSelectMenuTest()
        {
            MenuManager manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/Menu")).GetComponent<MenuManager>();
            manager.views = new MenuView[1];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/LevelSelectMenu")).GetComponent<MenuView>();
            manager.Start();
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(LevelSelectMenu));
        }
        [Test]
        public void ProfileSelectMenuTest()
        {
            MenuManager manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/Menu")).GetComponent<MenuManager>();
            manager.views = new MenuView[1];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/ProfileSelectMenu")).GetComponent<MenuView>();
            manager.Start();
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(ProfileMenu));
        }
        [Test]
        public void ProfileDetailMenuTest()
        {
            MenuManager manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/Menu")).GetComponent<MenuManager>();
            manager.views = new MenuView[1];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/ProfileDetailMenu")).GetComponent<MenuView>();
            manager.Start();
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(ProfileDetailMenu));
        }
        [Test]
        public void GameMenuTest()
        {
            MenuManager manager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/Menu")).GetComponent<MenuManager>();
            manager.views = new MenuView[3];
            manager.views[0] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/PauseMenu")).GetComponent<MenuView>();
            manager.views[1] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/DeathMenu")).GetComponent<MenuView>();
            manager.views[2] = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/LevelFinishMenu")).GetComponent<MenuView>();
            manager.Start();
            manager.GetViewStack()[manager.GetViewStack().Count - 1].TransitionTo(MenuEnum.GameDeath);
            manager.GetViewStack()[manager.GetViewStack().Count - 1].TransitionTo(MenuEnum.GameFinish);
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(GameMenu));
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(GameMenu));
            Assert.IsTrue(manager.GetViewStack()[0].GetType() == typeof(GameMenu));
        }
    }
}
