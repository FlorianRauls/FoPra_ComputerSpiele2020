using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{

    public GameObject projectilePrefab;

    public float cooldown = 4f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getCooldown()
    {
        return cooldown;
    }

    public void setCooldown(float newCooldown)
    {
        cooldown = newCooldown;
    }
    public float getTimer()
    {
        return timer;
    }
    public float setTimer(float newTimer)
    {
        timer = newTimer;
    }

    public Vector3 directionToTarget(GameObject target)
    {
        return transform.position - target.transform.position;
    }

    public float distanceToTarget(Vector3 direction)
    {
        return direction.magnitude;
    }
}
