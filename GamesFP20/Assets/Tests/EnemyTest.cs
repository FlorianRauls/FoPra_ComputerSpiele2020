using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EnemyTest
    {


        [Test]
        public void EnemyBasicMovementTest()
        {
            GameObject enemyObject = new GameObject();
            enemyObject.AddComponent<Enemy>();
            Enemy enemy = enemyObject.GetComponent<Enemy>();

            Assert.AreEqual(enemy.CalculateMovement(new Vector3(0, 0, 0), 1f, 1f,0).x, enemy.speed);
            Assert.AreEqual(enemy.CalculateMovement(new Vector3(0, 0, 0), -1f, 1f,0).x, -enemy.speed);
            Assert.AreEqual(enemy.CalculateMovement(new Vector3(0, 0, 0), 0f, 1f,0).y, enemy.speed);
            Assert.AreEqual(enemy.CalculateMovement(new Vector3(0, 0, 0), 0f, -1f,0).y, -enemy.speed);
        }

    }
}