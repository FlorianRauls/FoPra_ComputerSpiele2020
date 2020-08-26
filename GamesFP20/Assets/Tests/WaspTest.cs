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
            wasp.setTimer(5f);
            Assert.AreNotEqual(wasp.shootProjectile(new GameObject()),  null);
  
        }

        // Tests Wether Or Not The Projectile Will Be Fired In The Right Direction
        [Test]
        public void TestProjectileDirection()
        {
            GameObject waspObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Wasp"));
            WaspEnemy wasp = waspObject.GetComponent<WaspEnemy>();
            waspObject.transform.position = new Vector3(1, 1, 1);
            wasp.setCooldown(0f);
            wasp.setTimer(1f);
            wasp.setRange(15f);

            GameObject targetObject = new GameObject();
            targetObject.transform.position = new Vector3(0, 0, 0);


            Vector3 direction = waspObject.transform.position - targetObject.transform.position;
            float distance = direction.magnitude;
            direction = direction / distance;

            GameObject projectile = wasp.shootProjectile(targetObject);
            Debug.Log(projectile);
            Vector3 shouldBe = waspObject.transform.position + direction;


            Assert.IsTrue(shouldBe.x - projectile.transform.position.x < 0.15f); 
            Assert.IsTrue(shouldBe.y - projectile.transform.position.y < 0.15f);   
        }

        [Test]
        public void TestOnlyFireInRange()
        {
            GameObject waspObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Wasp"));
            WaspEnemy wasp = waspObject.GetComponent<WaspEnemy>();
            wasp.setRange(2f);
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
            GameObject waspObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Wasp"));
            WaspEnemy wasp = waspObject.GetComponent<WaspEnemy>();
            wasp.setRange(2f);
            wasp.setCooldown(1f);
            waspObject.transform.position = new Vector3(1, 1, 0);

            GameObject targetObjectInRange = new GameObject();
            targetObjectInRange.transform.position = new Vector3(0, 0, 0);     

            GameObject success = wasp.shootProjectile(targetObjectInRange);
            GameObject fail = wasp.shootProjectile(targetObjectInRange);

            Assert.AreNotEqual(null, success);
            Assert.AreEqual(null, fail);            


        }
    }
}
