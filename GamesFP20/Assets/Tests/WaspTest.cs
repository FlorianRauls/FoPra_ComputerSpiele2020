using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WaspTest
    {
        // Tests Wether Or Not The Projectile Will Be Spawned sucessfully
        [Test]
        public void TestProjectileSpawning()
        {
            GameObject waspObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Wasp"));
            WaspEnemy wasp = waspObject.GetComponent<WaspEnemy>();
            Assert.AreNotEqual(wasp.shootProjectile(null),  null);
  
        }

        // Tests Wether Or Not The Projectile Will Be Fired In The Right Direction
        [Test]
        public void TestProjectileDirection()
        {
            
        }

        [Test]
        public void TestOnlyFireInRange()
        {
            
        }
        public void TestOnlyFireAfterCooldownTime()
        {
            
        }
    }
}
