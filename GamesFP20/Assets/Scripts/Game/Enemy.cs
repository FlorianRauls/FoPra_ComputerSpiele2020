using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The base enemy class
// It's nevery deployed directly, just used for inheritance
public class Enemy : MonoBehaviour
{

    // The character Controller every enemy will use for movement
	private CharacterController controller;
    // movementspeed ( has to be fine tuned for every enemy )
	public float speed = 4;
    // Start is called before the first frame update

    // the basic version of Die() simply destroys the parten gameobject
    // this might get overwritten with deathanimations / triggers
    public void Die()
    {
        Destroy(this.gameObject);
    }

    // Move by the amount calculated by CalculateMovement
	public void Move(float horizontalInput, float verticalInput)
    {
		Vector3 velocity = controller.velocity;
		velocity = CalculateMovement(velocity, horizontalInput, verticalInput, Time.deltaTime);
		controller.Move(velocity * Time.deltaTime);
	}

    // Calculate movement amount/direction
	public Vector3 CalculateMovement(Vector3 currentMovement, float horizontalInput, float verticalInput, float deltaTime)
    {
		currentMovement.x = horizontalInput * speed;
        currentMovement.y = verticalInput * speed;;
		return currentMovement;
	}

    // Interface to make it easier for interactions between Colliders, Triggers and CharacterControllers
    public void collide(GameObject other)
    {

    }


}
