using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class JumpLimitTest
    {
         [Test]
        public void JumpCountTest()
        {
            GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
            Player boy = boyObject.GetComponent<Player>();
            boy.Start();

            Vector3 beforeTransform = boyObject.transform.position;
            boy.Move(0f, true);
            Assert.IsTrue(boyObject.transform.position.y > beforeTransform.x);

            beforeTransform = boyObject.transform.position;
            boy.Move(0f, true);
            Assert.IsTrue(boyObject.transform.position.y == beforeTransform.y);
        }
    }
}