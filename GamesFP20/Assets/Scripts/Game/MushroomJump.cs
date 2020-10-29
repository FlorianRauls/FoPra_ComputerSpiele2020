using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomJump : MonoBehaviour
{
    // This is the target we interacted with last
    public GameObject target = null;
     // the amount of force used to catapult target
    public float force = 8f;
    // Small cooldown and timer to
    // prevent bugs like infinite force applied
    public float cooldown = 1f;

    float timer = 5f;
    // Start is called before the first frame update
    public void Start()
    {
        // Search for a target directly
        // Not always necessary but 
        // prevents a rare bug
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Always tick the timer up
        timer = timer + Time.deltaTime;      
    }

    // Getter
    public GameObject GetTarget()
    {
        return target;
    }
    // Setter
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }
    // Collision Interface
    // If we did collide with a player
    // And cooldown is down
    // We set him as our new target and apply
    // Force to his movement
    // Afterwards cooldown is up
    public void Collide(GameObject other)
    {
        target = other;
        if(other.GetComponent<Player>() != null)
        {
            if(timer > cooldown)
            {
                timer = 0f;
                SetTarget(other);
                Player player = other.GetComponent<Player>();
                Vector3 vel = player.velocity;
                vel.y = 0f;
                player.GetController().Move((  vel + new Vector3(0f, force, 0f) )* Time.deltaTime);
            }
        }
    }
    // Setter
    public void SetCooldown(float newCd)
    {
        cooldown = newCd;
    }
    // Getter
    public float GetCooldown()
    {
        return cooldown;
    }
    // Setter
    public void SetTimer(float newCd)
    {
        timer = newCd;
    }
    // Getter
    public float GetTimer()
    {
        return timer;
    }
    // Getter
    public float GetObjectJumpHeight()
    {
        return target.GetComponent<Player>().jumpForce;
    }
    //Getter
    public Vector3 GetTargetVelocity()
    {
        if(target != null)
        {
            return target.GetComponent<Player>().velocity;
        }
        else{
            return new Vector3(0f, 0f, 0f);
        }
    }
    //Setter
    public void SetForce(float newForce)
    {
        force = newForce;
    }
    // Getter
    public float GetForce()
    {
        return force;
    }
    // on collision activate
    // The collision interface
    private void OnCollisionEnter(Collision other) {
        
        Collide(other.gameObject);    
    }
}

