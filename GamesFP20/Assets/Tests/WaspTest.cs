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
            GameObject waspObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Wasp"));
            WaspEnemy wasp = waspObject.GetComponent<WaspEnemy>();

            GameObject targetObject = new GameObject();
            targetObject.transform.position = new Vector3(0, 0, 0);


            Vector2 direction = waspObject.transform.position - targetObject.transform.position;
            float distance = direction.magnitude;
            direction = direction / distance;

            GameObject projectile = wasp.shootProjectile(targetObject);

            Assert.AreEqual(waspObject.transform.position + new Vector3(direction.x, direction.y, 0), projectile.transform.position);    
        }

        [Test]
        public void TestOnlyFireInRange()
        {
            GameObject waspObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Wasp"));
            WaspEnemy wasp = waspObject.GetComponent<WaspEnemy>();
            waspObject.transform.position = new Vector3(1, 1, 0);

            GameObject targetObjectInRange = new GameObject();
            targetObjectInRange.transform.position = new Vector3(0, 0, 0);     

            GameObject targetObjectOutRange = new GameObject();
            targetObjectOutRange.transform.position = new Vector3(50, 50, 50);      

            GameObject projectile = wasp.shootProjectile(targetObjectInRange);
            GameObject failedProjectile = wasp.shootProjectile(targetObjectOutRange);  

            Assert.AreNotEqual(null, projectile);
            Assert.AreEqual(null, failedProjectile);
        }
        public void TestOnlyFireAfterCooldownTime()
        {
            
        }
    }
}
