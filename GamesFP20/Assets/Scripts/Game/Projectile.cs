using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Enemy
{
    GameObject target;
    Vector3 targetDirection;

    bool destroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetDirection, -step);
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

    public Vector3 getTargetDirection()
    {
        return targetDirection;
    }

    public void setTargetDirection(Vector3 newLocation)
    {
        targetDirection = newLocation;
    }
}
