using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  This class handles all behaviours associated with objects in the gameworld
/// which Player, PlayerTwo or FriendlyProjectile could interact with.
/// </summary>
public class Interactable : MonoBehaviour
{
    // This is the amount we want to rotate on interaction
    public Vector3 amount;
    // since we have to rotate this instead of the actual tree, we save the child as reference
    Transform child;
    // as well as its collider
    Collider childCollider;
    bool interacted = false;
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
    public void SetAmount(Vector3 newAmount)
    {
        amount = newAmount;
    }
    // if we interact properly we rotate by amount, as referenced by our own space
    public void Rotate()
    {
        interacted = true;
        transform.Rotate(amount.x, amount.y, amount.z, Space.Self);
    }
    // This is the common interface for collision handling
    // If we collide with a Friendly object we rotate/interact with it
    public void Collide(GameObject other)
    {
        if(other.tag =="Friendly")
        {
            if(!interacted)
                Rotate();
        }
    }
}
