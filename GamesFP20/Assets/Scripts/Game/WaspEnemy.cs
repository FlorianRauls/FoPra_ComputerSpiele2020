using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspEnemy : Enemy
{
    public GameObject projectilePrefab;
    GameObject target;
    
    float cooldown = 3f;

    float timer = 0f;
    float range = 15f;
    GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer = timer + Time.deltaTime;

        if(target != null)
        {

            shootProjectile(target);
            
        }
    }

    public GameObject shootProjectile(GameObject target)
    {
        if(timer < cooldown)
        {
            return null;
        }
        else
        {
            timer = 0f;
        }

        // get direction to target and normalize it by dividing through distance to target
        Vector2 direction = directionToTarget(target);
        float distance = distanceToTarget(direction);

        if(distance == 0f)
        {
            distance = 0.0000001f;
        }

        Vector2 normalized_direction = direction / distance;

        if(distance > range)
        {
            
            return null;
        }



        GameObject projectile = Instantiate(projectilePrefab,
         transform.position + new Vector3(normalized_direction.x,
            normalized_direction.y, 0f), transform.rotation);
        

        return projectile;
    }

    public Vector3 directionToTarget(GameObject target)
    {
        return transform.position - target.transform.position;
    }

    public float distanceToTarget(Vector3 direction)
    {
        return direction.magnitude;
    }

    public void setCooldown(float newCooldown)
    {
        cooldown = newCooldown;
    }

    public float getCooldown()
    {
        return cooldown;
    }

    public void setRange(float newRange)
    {
        range = newRange;
    }

    public float getRange()
    {
        return range;
    }

    public void setTimer(float newTimer)
    {
        timer = newTimer;
    }

    public float getTimer()
    {
        return timer;
    }


}
