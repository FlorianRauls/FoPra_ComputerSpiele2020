﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspEnemy : Enemy
{
    public GameObject projectilePrefab;
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
        Vector2 direction = transform.position - target.transform.position;

        return projectile;
    }


}
