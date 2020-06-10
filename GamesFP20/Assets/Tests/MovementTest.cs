using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MovementTest
    {
        [Test]
        public void BasicMovementCalculationTest()
        {
            GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
            Player boy = boyObject.GetComponent<Player>();
            Assert.AreEqual(boy.CalculateMovement(new Vector3(0, 0, 0), 1f, false,0).x, boy.speed);
            Assert.AreEqual(boy.CalculateMovement(new Vector3(0, 0, 0), -1f, false,0).x, -boy.speed);
            Assert.AreEqual(boy.CalculateMovement(new Vector3(0, 0, 0), 0f, true,0).y, boy.jumpForce);

        }

        [Test]
        public void ActualBasicMovementTest()
        {
            GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
            Player boy = boyObject.GetComponent<Player>();
            boy.Start();

            Vector3 beforeTransform = boyObject.transform.position;
            boy.Move(1f, false);
            Assert.IsTrue(boyObject.transform.position.x > beforeTransform.x);

            beforeTransform = boyObject.transform.position;
            boy.Move(-1f, false);
            Assert.IsTrue(boyObject.transform.position.x < beforeTransform.x);

            beforeTransform = boyObject.transform.position;
            boy.Move(0f, true);
            Assert.IsTrue(boyObject.transform.position.y > beforeTransform.y);
        }
    }
}
