using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MovementTest
    {
        double delta = 0.5;
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
        [Test]
        public void TestNotJumpWhenNotGrounded()
        {
            GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
            Player boy = boyObject.GetComponent<Player>();
            boy.Start();
            Vector3 before = boy.transform.position;
            boy.setGrounded(false);
            boy.Move(0, true);
            Assert.AreEqual(before.x, boy.transform.position.x, delta);
            Assert.AreEqual(before.y, boy.transform.position.y, delta);
            Assert.AreEqual(before.z, boy.transform.position.z, delta);
        }
        [Test]
        public void TestJumpWhenGrounded()
        {
            GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
            Player boy = boyObject.GetComponent<Player>();
            boy.Start();
            Vector3 before = boy.transform.position;
            boy.setGrounded(true);
            boy.Move(0, true);
            Assert.AreNotEqual(before, boy.transform.position);
        }
    }
}
