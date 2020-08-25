using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspEnemy : Enemy
{
    public GameObject projectilePrefab;
    
    float cooldown = 3f;
    float range = 15f;
    GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject shootProjectile(GameObject target)
    {
        // get direction to target and normalize it by dividing through distance to target
        Vector2 direction = transform.position - target.transform.position;
        float distance = direction.magnitude;
        direction = direction / distance;

        
        GameObject projectile = Instantiate(projectilePrefab, transform.position + new Vector3(direction.x, direction.y, 0f), transform.rotation);
        

        return projectile;
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


}
