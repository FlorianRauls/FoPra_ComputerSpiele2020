using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomJump : MonoBehaviour
{

    public GameObject target = null;
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
        SetTarget(other);
    }

    public float GetObjectJumpHeight()
    {
        
    }
}

