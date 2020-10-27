using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
private void OnTriggerEnter(Collider other) {
    transform.parent.GetComponent<Interactable>().Collide(other.gameObject);   
}
}
