using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyProjectile : MonoBehaviour
{
    GameObject target;
    Vector3 targetDirection;

    bool destroyed = false;


   public Vector3 rotationDirection = new Vector3(0,0,1);
   public float smoothTime = 5f;
   private float convertedTime = 200;
   private float smooth = 5f;
   public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetDirection + transform.position, -step);

        float smooth = Time.deltaTime * smoothTime * convertedTime;
        transform.Rotate(rotationDirection * smooth);
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }


    public void collide(GameObject other)
    {
        if(other.tag == "Enemy" || other.tag == "Untagged" || other.tag == "Ground")
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
