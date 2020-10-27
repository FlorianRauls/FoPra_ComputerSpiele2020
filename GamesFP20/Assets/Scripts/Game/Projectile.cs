using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Enemy
{
    // our target ibject used for reference
    GameObject target;
    Vector3 targetDirection;

    bool destroyed = false;

    // These variables are all fluff used to
    // roate the projectile whilst flying
   public Vector3 rotationDirection = new Vector3(0,0,1);
   public float smoothTime = 5f;
   private float convertedTime = 200;
   private float smooth = 5f;

    // Update is called once per frame
    void Update()
    {   
        // Calculate the movement by getting the stepsize and inserting it into MoveTowards
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetDirection + transform.position, -step);

        // Fluff for rotating the projectil whilst flying
        float smooth = Time.deltaTime * smoothTime * convertedTime;
        transform.Rotate(rotationDirection * smooth);
    }

    // Common Collision Interface
    // When we collide with anything
    // We get destroyed
    public void collide(GameObject other)
    {
        if(other.tag == "Player" || other.tag == "Untagged" || other.tag == "Ground" || other.tag =="Friendly")
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

    // On Collision trigger the common collision interface

    private void OnCollisionEnter(Collision other) {
        collide(other.gameObject);
    }

}
