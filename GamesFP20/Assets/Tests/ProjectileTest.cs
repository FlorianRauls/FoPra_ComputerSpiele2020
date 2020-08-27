using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ProjectileTest : MonoBehaviour
{


        [Test]
        public void TestNotDyingOnCollisionWithEnemy()
        {
            GameObject projectileObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Projectile"));
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            GameObject gameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Wasp"));


            projectile.collide(gameObject);
            
            Assert.IsTrue(!projectile.getDestroyed());
        }

        [Test]
        public void TestDyingOnCollisionWithPlayer()
        {
            GameObject projectileObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Projectile"));
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            GameObject gameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));


            projectile.collide(gameObject);
            
            Assert.IsTrue(projectile.getDestroyed());
        }
                
        // Tests Destruction Of Projectile After Collision With ground
        [Test]
        public void TestDestructionOnGroundCollision()
        {
            GameObject projectileObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Projectile"));
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            GameObject gameObject = new GameObject();

            projectile.collide(gameObject);
            
            Assert.IsTrue(projectile.getDestroyed());
        }

        [Test]
        public void TestReceivingTarget()
        {
            GameObject projectileObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Projectile"));
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            GameObject gameObject = new GameObject();

            projectile.setTarget(gameObject);
            
            Assert.AreEqual(projectile.getTarget(), gameObject);
        }

        [Test]
        public void TestGettingTargetLocation()
        {
             GameObject projectileObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Projectile"));
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            GameObject gameObject = new GameObject();

            projectile.setTargetDirection(gameObject.transform.position);
            
            Assert.AreEqual(projectile.getTargetDirection(), gameObject.transform.position);               
        }
}
