using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Enemy
{
    GameObject target;
    Vector3 targetPosition;

    bool destroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void collide(GameObject other)
    {
        if(other.tag == "Player" || other.tag == "Untagged" || other.tag == "Ground")
        {
            setDetroyed(true);
            Die();
        }
    }

    public bool getDestroyed()
    {
        return destroyed;
    }
    public void setDetroyed(bool newDestroyed)
    {
        destroyed = newDestroyed;
    }

    public GameObject getTarget()
    {
        return target;
    }

    public void setTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    public Vector3 getTargetLocation()
    {
        return targetPosition;
    }

    public void setTargetLocation(Vector3 newLocation)
    {
        targetPosition = newLocation;
    }
}
