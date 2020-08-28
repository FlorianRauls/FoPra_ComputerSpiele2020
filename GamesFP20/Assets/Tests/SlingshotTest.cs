using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SlingshotTest : MonoBehaviour
{
        // Tests Wether Or Not The Projectile Will Be Spawned sucessfully
        [Test]
        public void TestProjectileSpawning()
        {
            GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
            Slingshot sling = boyObject.GetComponent<Slingshot>();
            sling.setTimer(5f);
            Assert.AreNotEqual(sling.shootProjectile(new GameObject()),  null);
  
        }

        // Tests Wether Or Not The Projectile Will Be Fired In The Right Direction
        [Test]
        public void TestProjectileDirection()
        {
            GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
            Slingshot sling = boyObject.GetComponent<Slingshot>();
            boyObject.transform.position = new Vector3(1, 1, 1);
            sling.setCooldown(0f);
            sling.setTimer(1f);
            sling.setRange(15f);

            GameObject targetObject = new GameObject();
            targetObject.transform.position = new Vector3(0, 0, 0);


            Vector3 direction = boyObject.transform.position - targetObject.transform.position;
            float distance = direction.magnitude;
            direction = direction / distance;

            GameObject projectile = sling.shootProjectile(targetObject);
            Vector3 shouldBe = boyObject.transform.position - direction;


            Assert.IsTrue(shouldBe.x - projectile.transform.position.x < 0.15f); 
            Assert.IsTrue(shouldBe.y - projectile.transform.position.y < 0.15f);   
        }

        [Test]
        public void TestOnlyFireAfterCooldownTime()
        {
            GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
            Slingshot sling = boyObject.GetComponent<Slingshot>();
            sling.setRange(5f);
            sling.setCooldown(1f);
            boyObject.transform.position = new Vector3(1, 1, 0);

            GameObject targetObjectInRange = new GameObject();
            targetObjectInRange.transform.position = new Vector3(0, 0, 0);     

            sling.setTimer(2f);
            GameObject success = sling.shootProjectile(targetObjectInRange);
            GameObject fail = sling.shootProjectile(targetObjectInRange);

            Assert.AreNotEqual(null, success);
            Assert.AreEqual(null, fail);            
        }
}
