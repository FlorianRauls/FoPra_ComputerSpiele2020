﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // This is the amount we want to rotate on interaction
    public Vector3 amount;
    // since we have to rotate this instead of the actual tree, we save the child as reference
    Transform child;
    // as well as its collider
    Collider childCollider;
    // Start is called before the first frame update
    public void Start()
    {
        // getting our variables
        child = transform.GetChild(0);
        childCollider = child.gameObject.GetComponent<Collider>();
    }


    // getter
    public Collider GetChildCollider()
    {
        return childCollider;
    }
    // getter
    public Transform GetChild()
    {
        return child;
    }
    // if we interact properly we rotate by amount, as referenced by our own space
    public void Rotate()
    {
        transform.Rotate(amount.x, amount.y, amount.z, Space.Self);
    }

    // This is the common interface for collision handling
    // If we collide with a Friendly object we rotate/interact with it
    public void Collide(GameObject other)
    {
        if(other.tag =="Friendly")
        {
            Rotate();
        }

    }
}
