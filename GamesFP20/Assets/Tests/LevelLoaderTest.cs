using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LevelLoaderTest
    {
        [Test]
        public void StartTest()
        {
            LevelLoader levelLoader = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/LevelLoader")).GetComponent<LevelLoader>();
            levelLoader.Start();
            Assert.IsTrue(levelLoader.GetCurrentLevel() != null);
            Assert.IsTrue(levelLoader.GetCurrentDividerLevel() != null);
        }

        [Test]
        public void NextLevelTest()
        {
            LevelLoader levelLoader = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/LevelLoader")).GetComponent<LevelLoader>();
            levelLoader.Start();
            Level lastLevel = levelLoader.GetCurrentLevel();
            Level lastLevelDivider = levelLoader.GetCurrentDividerLevel();
            int lastLevelID = LevelLoader.levelIndex;
            levelLoader.LoadNextLevel();
            Assert.IsTrue(levelLoader.GetCurrentLevel() != lastLevel);
            Assert.IsTrue(levelLoader.GetCurrentDividerLevel() != lastLevelDivider);
            Assert.IsTrue(LevelLoader.levelIndex != lastLevelID);
        }
    }
}
