using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  This class handles all behaviours associated with Wasp, the most commonly used
/// Enemy asset in the gameworld.
/// </summary>
public class WaspEnemy : Enemy
{
    /// The Object we fire
    public GameObject projectilePrefab;
    /// Our target as reference
    GameObject target;
    
    /// Cooldown after which we can fire
    public float cooldown = 3f;
    /// timer to track time / Check for cooldown
    float timer = 0f;
    /// Our Range we can fire at
    public float range = 15f;
    /// We fly up and down by a small amount
    public float amplitude = 0.3f;
    public float frequency = 0.3f;
    GameObject projectile;
    GameObject[] possibleTargets = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
         // We check for all players in the level
        possibleTargets = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Track the time passed
        timer = timer + Time.deltaTime;
        // If we have a target
        if(target != null)
        {
            // And the cooldown is up
            // we shoot
            if(timer > cooldown)
                shootProjectile(target);
            
        }
         // Afterwards check again for targets
        target = SearchTarget(possibleTargets);
        // Fluff for going up and down
        Vector3 copyPosition = transform.position;
        copyPosition.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * Time.deltaTime * amplitude;
        transform.position = copyPosition;
    }


    /// Searches Through all possible candidates and returns the one that
    /// is closest to this object in the game world.
    public GameObject SearchTarget(GameObject[] candidates)
    {
        // If we don't have any candidates we don't need to bother
        if(candidates == null ||candidates.Length == 0)
        {
            return null;
        }
        // Else
        if(target != null)
        {
            // If our target is still in range we can keep it
            if(distanceToTarget(directionToTarget(target)) < range)
                return target;
            else
            {
                // Go through all candidates, compare the distance from them to us
                // And return the closest one
                GameObject closestEnemy = candidates[0];
                float shortestDist = distanceToTarget(directionToTarget(closestEnemy));
                foreach(GameObject candidate in candidates)
                {
                    float currentDist = distanceToTarget(directionToTarget(candidate));
                    if(currentDist < shortestDist);
                    {
                        shortestDist = currentDist;
                        closestEnemy = candidate;
                    }
                }
                return closestEnemy;                
            }
        }
        else
        {
            GameObject closestEnemy = candidates[0];
            float shortestDist = distanceToTarget(directionToTarget(closestEnemy));
            foreach(GameObject candidate in candidates)
            {
                float currentDist = distanceToTarget(directionToTarget(candidate));
                if(currentDist < shortestDist);
                {
                    shortestDist = currentDist;
                    closestEnemy = candidate;
                }
            }
            return closestEnemy;
        }
    }
    /// This method handles all 
    /// necessary steps for shooting a Projectile 
    /// onto the given target GameObject.
    public GameObject shootProjectile(GameObject target)
    {
        // For safety we check the cooldown again
        if(timer < cooldown)
        {
            return null;
        }
        else
        {
            // Reset the timer
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

        // If target is out of range we won't shoot
        if(distance > range)
        {
            
            return null;
        }


        // Instantiate a projectile and move it towards the enemy
        GameObject projectile = Instantiate(projectilePrefab,
         transform.position - new Vector3(normalized_direction.x,
            normalized_direction.y, 0f), transform.rotation);
        // Set the target for our new projectile
        projectile.GetComponent<Projectile>().setTarget(target);
        // Set the normalized direction for our new projectile
        projectile.GetComponent<Projectile>().setTargetDirection(normalized_direction);
        return projectile;
    }

    /// Calculates the direction towards another object
    public Vector3 directionToTarget(GameObject target)
    {
        return transform.position - target.transform.position;
    }

    /// Calculates the distance to another object
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

    public GameObject getTarget()
    {
        return target;
    }

    public void setTarget(GameObject newTarget)
    {
        target = newTarget;
    }

private void OnCollisionEnter(Collision other) {
    collide(other.gameObject);
}

// Common collision interface
// If we collide with a friendly projectile we die
public void collide(GameObject other)
{
    if(other.tag == "Friendly")
    {
        Die();
    }
}

}
