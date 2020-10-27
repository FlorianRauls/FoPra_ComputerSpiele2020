using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    // The projectile we will shoot
    public GameObject projectilePrefab;
    // Cooldown after which we are allowed to shoot again
    public float cooldown = 4f;
    // Timer to keep track of cooldowns
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;
    }

    public GameObject shootProjectile(GameObject target)
    {
        // If our cooldown is up we won't shoot
        if(timer < cooldown)
        {
            return null;
        }
        // Else reset the cooldown
        else
        {
            timer = 0f;
        }

        // get direction to target and normalize it by dividing through distance to target
        Vector2 direction = directionToTarget(target);
        float distance = distanceToTarget(direction);

        // Prevents division by zero
        if(distance == 0f)
        {
            distance = 0.0000001f;
        }
         // Normalize the direction
        Vector2 normalized_direction = direction / distance;

        // Instantiate a new projectile...
        GameObject projectile = Instantiate(projectilePrefab,
         transform.position - new Vector3(normalized_direction.x,
            normalized_direction.y, 0f), transform.rotation);

        // ... and give it our target and the direction towards it
        projectile.GetComponent<FriendlyProjectile>().setTarget(target);
        projectile.GetComponent<FriendlyProjectile>().setTargetDirection(normalized_direction);

        return projectile;
    }
    public float getCooldown()
    {
        return cooldown;
    }

    public void setCooldown(float newCooldown)
    {
        cooldown = newCooldown;
    }
    public float getTimer()
    {
        return timer;
    }
    public void setTimer(float newTimer)
    {
        timer = newTimer;
    }

    // Calculate the direction towards an object
    public Vector3 directionToTarget(GameObject target)
    {
        return transform.position - target.transform.position;
    }

    // Calculates the distance to an object, given the direction
    public float distanceToTarget(Vector3 direction)
    {
        return direction.magnitude;
    }
}
