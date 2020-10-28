using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GameManagerTest
    {
        [Test]
        public void StartTest()
        {
            GameManager gameManager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager")).GetComponent<GameManager>();
            gameManager.Start();
            Assert.IsTrue(gameManager.GetCurrentLevel() != null);
            Assert.IsTrue(gameManager.GetCurrentDividerLevel() != null);
        }

        [Test]
        public void NextLevelTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/ProfileManager")).GetComponent<ProfileManager>().Start();
            GameManager gameManager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/GameManager")).GetComponent<GameManager>();
            MenuManager.ClearInstance();
            gameManager.Start();
            Level lastLevel = gameManager.GetCurrentLevel();
            Level lastLevelDivider = gameManager.GetCurrentDividerLevel();
            int lastLevelID = GameManager.levelIndex;
            gameManager.LoadNextLevel();
            Assert.IsTrue(gameManager.GetCurrentLevel() != lastLevel);
            Assert.IsTrue(gameManager.GetCurrentDividerLevel() != lastLevelDivider);
            Assert.IsTrue(GameManager.levelIndex != lastLevelID);
        }
    }
}
