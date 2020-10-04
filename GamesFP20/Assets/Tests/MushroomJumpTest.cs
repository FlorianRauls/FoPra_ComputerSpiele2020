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
        shroom.Start();

        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();


        
        shroom.Collide(boyObject);
        Assert.AreEqual(boyObject, shroom.GetTarget());

    }

    [Test]
    public void TestGettingPlayerJumpHeight()
    {
        GameObject shroomObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/JumpShroom"));
        MushroomJump shroom = shroomObject.GetComponent<MushroomJump>();
        shroom.Start();

        Debug.Log(shroom.GetTarget());

        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();


        shroom.Collide(boyObject);

        float playerHeight = shroom.GetObjectJumpHeight();
        Assert.AreEqual(boy.jumpForce, playerHeight);

    }

    [Test]
    public void TestGettingPlayerVelocity()
    {
        GameObject shroomObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/JumpShroom"));
        MushroomJump shroom = shroomObject.GetComponent<MushroomJump>();
        shroom.Start();

        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();


        boy.velocity = new Vector3(1f, 1f, 1f);

        shroom.Collide(boyObject);  

        Assert.AreEqual(new Vector3(1f, 1f, 1f), shroom.GetTargetVelocity());   
    }

    // Due to the fact that the player object CANNOT be moved in tests without any commands
    // and that the nature of jumps has to be very finely tuned while playtesting
    // it is enough to test THAT the player has moved and not exactly where he has moved
    [Test]
    public void TestMakingPlayerJump()
    {
        GameObject shroomObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/JumpShroom"));
        MushroomJump shroom = shroomObject.GetComponent<MushroomJump>();
        shroom.Start();

        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();


        Vector3 beforePosition = new Vector3(0f, 0f, 0f);
        boyObject.transform.position = beforePosition;

        float force = 5f;
        shroom.SetForce(force);

        shroom.Collide(boyObject);

        Assert.AreNotEqual(boyObject.transform.position, beforePosition);
    }

    [Test]
    public void TestNotWorkWithCooldownUp()
    {
        GameObject shroomObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/JumpShroom"));
        MushroomJump shroom = shroomObject.GetComponent<MushroomJump>();
        shroom.Start();

        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();



        Vector3 beforePosition = new Vector3(0f, 0f, 0f);
        boyObject.transform.position = beforePosition;

        float force = 5f;
        shroom.SetForce(force);
        shroom.SetTimer(-5f);
        shroom.Collide(boyObject);

        Assert.AreEqual(boyObject.transform.position, beforePosition + new Vector3(0f, 0f, 0f));

    }


    public void TestWorkWithCooldownDown()
    {
        GameObject shroomObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/JumpShroom"));
        MushroomJump shroom = shroomObject.GetComponent<MushroomJump>();
        shroom.Start();

        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();



        Vector3 beforePosition = new Vector3(0f, 0f, 0f);
        boyObject.transform.position = beforePosition;

        float force = 5f;
        shroom.SetForce(force);
        shroom.SetTimer(5f);
        shroom.Collide(boyObject);

        Assert.AreEqual(boyObject.transform.position, beforePosition + new Vector3(0f, force, 0f));

    }
}
