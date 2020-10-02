using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomJump : MonoBehaviour
{

    public GameObject target = null;

    float force = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            SetTarget(other);
            Player player = other.GetComponent<Player>();
            Vector3 vel = player.velocity;
            vel.y = 0f;
            player.GetController().Move(vel + new Vector3(0f, force, 0f) * Time.deltaTime);
        }

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

