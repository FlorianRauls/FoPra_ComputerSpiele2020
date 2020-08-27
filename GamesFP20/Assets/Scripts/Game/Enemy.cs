using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	private CharacterController controller;
	public float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // the basic version of Die() simply destroys the parten gameobject
    // this might get overwritten with deathanimations / triggers
    public void Die()
    {
        Destroy(this.gameObject);
    }


	public void Move(float horizontalInput, float verticalInput)
    {
		Vector3 velocity = controller.velocity;
		velocity = CalculateMovement(velocity, horizontalInput, verticalInput, Time.deltaTime);
		controller.Move(velocity * Time.deltaTime);
	}

	public Vector3 CalculateMovement(Vector3 currentMovement, float horizontalInput, float verticalInput, float deltaTime)
    {
		currentMovement.x = horizontalInput * speed;
        currentMovement.y = verticalInput * speed;;
		return currentMovement;
	}

    public void collide(GameObject other)
    {

    }


}
