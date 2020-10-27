using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used for the projectiles, fired by the player
public class FriendlyProjectile : MonoBehaviour
{
    // target is the (often empty) GameObject
    // from which we can derive properties like direction etc
    GameObject target;
    Vector3 targetDirection;

    // Check if this is destroyed
    bool destroyed = false;

    // This is fluff to make the projectile rotate when flying 
   public Vector3 rotationDirection = new Vector3(0,0,1);
   public float smoothTime = 5f;
   private float convertedTime = 200;
   private float smooth = 5f;
   // Movementspeed
   public float speed = 4f;

    // Update is called once per frame
    void Update()
    {

        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetDirection + transform.position, -step);
        // Again Fluff to rotate whilst flying
        float smooth = Time.deltaTime * smoothTime * convertedTime;
        transform.Rotate(rotationDirection * smooth);
    }

    // Interface to destroy this object
    public void Die()
    {
        Destroy(this.gameObject);
    }

    // Common collision interface
    public void collide(GameObject other)
    {
        if(other.tag == "Enemy" || other.tag == "Untagged" || other.tag == "Ground")
        {
            setDetroyed(true);
            Die();
        }
    }

    // Getter
    public bool getDestroyed()
    {
        return destroyed;
    }

    // Setter
    public void setDetroyed(bool newDestroyed)
    {
        destroyed = newDestroyed;
    }
    // Getter
    public GameObject getTarget()
    {
        return target;
    }
    //Setter
    public void setTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    // Getter
    public Vector3 getTargetDirection()
    {
        return targetDirection;
    }

    // Setter
    public void setTargetDirection(Vector3 newLocation)
    {
        targetDirection = newLocation;
    }

    // We send a Message to the enemies collision interface
    // Since Character Controllers are awful at detecing collision themselves
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.transform.SendMessage("collide", this.gameObject);
        }
    }
}
