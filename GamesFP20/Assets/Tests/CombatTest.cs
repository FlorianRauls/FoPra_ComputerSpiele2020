using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class CombatTest : MonoBehaviour
{

    [Test]
    public void TestOpenMenuOnDefeat()
    {
        GameManager.ClearInstance();
        MenuManager.ClearInstance();
        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();

        boy.defeat();

        Assert.AreEqual(boy.getInMenu(), true);

    }

    [Test]
    public void TestDefeatOnCollisionWithEnemy()
    {
        GameManager.ClearInstance();
        MenuManager.ClearInstance();
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
        GameManager.ClearInstance();
        MenuManager.ClearInstance();
        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();

        boy.defeat();

        Assert.AreEqual(boy.GetComponent<CharacterController>().enabled, false);

    }

    [Test]
    public void TestUndefeatableInMenu()
    {
        GameObject boyObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        Player boy = boyObject.GetComponent<Player>();
        boy.Start();

        boy.setInMenu(true);

        boy.defeat();

        Assert.AreEqual(boy.getDefeated(), false);
    }
}
