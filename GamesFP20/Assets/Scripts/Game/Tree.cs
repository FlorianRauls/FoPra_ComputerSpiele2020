using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  This class exists only to send Trigger Events to Interactable.
/// </summary>
public class Tree : MonoBehaviour
{
private void OnTriggerEnter(Collider other) {
    transform.parent.GetComponent<Interactable>().Collide(other.gameObject);   
}
}
