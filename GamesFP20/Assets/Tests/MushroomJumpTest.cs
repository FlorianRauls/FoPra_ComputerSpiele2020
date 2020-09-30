using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MushroomJumpTest : MonoBehaviour
{
    [Test]
    public void TestGetCollision()
    {

        GameObject shroomObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/JumpShroom"));
        MushroomJump shroom = shroomObject.GetComponent<MushroomJump>();

        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();

        shroom.Collide(boyObject);

        Assert.AreEqual(boyObject, shroom.GetTarget());

    }

    [Test]
    public void TestGettingPlayerJumpHeight()
    {

    }

    [Test]
    public void TestMakingPlayerJump()
    {

    }
}
