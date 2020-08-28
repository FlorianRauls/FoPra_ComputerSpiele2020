using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class CombatTest : MonoBehaviour
{

    [Test]
    public void TestOpenDefeatMenuOnDefeat()
    {
        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();

        boy.Defeat();

        Assert.AreEqual(boy.getDefeatMenuOpen(), true);

    }

    [Test]
    public void TestDefeatOnCollisionWithEnemy()
    {
        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();

        GameObject projectileObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Projectile"));
        
        boy.collide(projectileObject);

        Assert.AreEqual(boy.getDefeated(), true);
    }

    [Test]
    public void TestDisableMovementOnDefeat()
    {
        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();

    }

    [Test]
    public void TestUndefeatableInLevelMenu()
    {
        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();

    }

    [Test]
    public void TestUndefeatableInLevelAccomplisedMenu()
    {
        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();

    }
}
