using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspEnemy : Enemy
{
    public GameObject projectilePrefab;
    GameObject target;
    
    float cooldown = 3f;

    float timer = 0f;
    public float range = 15f;

    public float amplitude = 0.3f;
    public float frequency = 0.3f;
    GameObject projectile;
    GameObject[] possibleTargets = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        possibleTargets = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        timer = timer + Time.deltaTime;
        if(target != null)
        {
            if(timer > cooldown)
                shootProjectile(target);
            
        }

        target = SearchTarget(possibleTargets);

        Vector3 copyPosition = transform.position;
        copyPosition.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * Time.deltaTime * amplitude;
        transform.position = copyPosition;
    }


    // TODO: refactor this function such that it does not take so much lines of code
    public GameObject SearchTarget(GameObject[] candidates)
    {
        if(candidates == null ||candidates.Length == 0)
        {
            return null;
        }
        
        if(target != null)
        {
            if(distanceToTarget(directionToTarget(target)) < range)
                return target;
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
         transform.position - new Vector3(normalized_direction.x,
            normalized_direction.y, 0f), transform.rotation);
        
        projectile.GetComponent<Projectile>().setTarget(target);
        projectile.GetComponent<Projectile>().setTargetDirection(normalized_direction);
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

}
