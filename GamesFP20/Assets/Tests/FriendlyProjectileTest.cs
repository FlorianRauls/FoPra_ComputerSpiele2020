﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FriendlyProjectileTest : MonoBehaviour
{
    [Test]
        public void TestGettingTargetLocation()
        {
            GameObject projectileObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/FriendlyProjectile"));
            FriendlyProjectile projectile = projectileObject.GetComponent<FriendlyProjectile>();

            GameObject gameObject = new GameObject();

            projectile.setTargetDirection(gameObject.transform.position);
            
            Assert.AreEqual(projectile.getTargetDirection(), gameObject.transform.position);               
        }

        [Test]
        public void TestNotDyingOnCollisionWithPlayer()
        {
            GameObject projectileObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
            FriendlyProjectile projectile = projectileObject.GetComponent<FriendlyProjectile>();

            GameObject gameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));


            projectile.collide(gameObject);
            
            Assert.IsTrue(!projectile.getDestroyed());
        }

        [Test]
        public void TestDyingOnCollisionWithEnemy()
        {
            GameObject projectileObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/FriendlyProjectile"));
            FriendlyProjectile projectile = projectileObject.GetComponent<FriendlyProjectile>();
            
            GameObject gameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Wasp"));


            projectile.collide(gameObject);
            
            Assert.IsTrue(projectile.getDestroyed());
        }
                
        // Tests Destruction Of Projectile After Collision With ground
        [Test]
        public void TestDestructionOnGroundCollision()
        {
            GameObject projectileObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/FriendlyProjectile"));
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            GameObject gameObject = new GameObject();

            projectile.collide(gameObject);
            
            Assert.IsTrue(projectile.getDestroyed());
        }
}
