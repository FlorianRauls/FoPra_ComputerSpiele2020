using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Enemy
{

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
}
