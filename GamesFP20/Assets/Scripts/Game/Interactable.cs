using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public Vector3 amount;

    Transform child;
    Collider childCollider;
    // Start is called before the first frame update
    public void Start()
    {
        child = transform.GetChild(0);
        childCollider = child.gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Collider GetChildCollider()
    {
        return childCollider;
    }

    public Transform GetChild()
    {
        return child;
    }

    public void Rotate()
    {
        transform.Rotate(amount.x, amount.y, amount.z, Space.World);
    }

    public void Collide(GameObject other)
    {
        if(other.tag =="Friendly")
        {
            Rotate();
        }

    }
}
