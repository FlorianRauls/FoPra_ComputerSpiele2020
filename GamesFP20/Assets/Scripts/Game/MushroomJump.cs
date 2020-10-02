using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomJump : MonoBehaviour
{

    public GameObject target = null;

    float force = 10f;
    float cooldown = 1f;

    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;      
    }

    public GameObject GetTarget()
    {
        return target;
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    public void Collide(GameObject other)
    {
        if(other.GetComponent<Player>() != null)
        {
            if(timer > cooldown)
            {
                timer = 0f;
                SetTarget(other);
                Player player = other.GetComponent<Player>();
                Vector3 vel = player.velocity;
                vel.y = 0f;
                player.GetController().Move(vel + new Vector3(0f, force, 0f) * Time.deltaTime);
            }

        }

    }

    public void SetCooldown(float newCd)
    {
        cooldown = newCd;
    }

    public float GetCooldown()
    {
        return cooldown;
    }

    public void SetTimer(float newCd)
    {
        timer = newCd;
    }

    public float GetTimer()
    {
        return timer;
    }

    public float GetObjectJumpHeight()
    {
        if(target != null)
        {
            return target.GetComponent<Player>().jumpForce;
        }
        else{
            return 0f;
        }
    }

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

    public void SetForce(float newForce)
    {
        force = newForce;
    }

    public float GetForce()
    {
        return force;
    }

    private void OnCollisionEnter(Collision other) {
        
        Collide(other.gameObject);
        
    }
}

