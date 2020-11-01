using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the base class used by any Enemy Type in the game.
/// </summary>
public class Enemy : MonoBehaviour
{
    /// Any Enemy nees a CharacterController to move through the world.
	protected CharacterController controller; 
    /// This determines the speed with which the enemy can move in any direction.
	public float speed = 4; 

/// <summary>
/// This method should be triggered on death by any Enemy in the game.
/// On default it destroys the object.
/// </summary>
    public void Die()
    {
        Destroy(this.gameObject);
    }

/// <summary>
/// Default method used by any Enemy to move through the game world.
/// It copys the Player class by requiring a horizontalInput and vertialInput
/// determined by game circumstances.
/// </summary>
/// <param name="horizontalInput"></param> <param name="verticalInput"></param>
	public void Move(float horizontalInput, float verticalInput)
    {
		Vector3 velocity = controller.velocity;
		velocity = CalculateMovement(velocity, horizontalInput, verticalInput, Time.deltaTime);
		controller.Move(velocity * Time.deltaTime);
	}

/// <summary>
/// Default method used by any Enemy to calculate how much it can move based on inputs
/// passed down by Move
/// </summary>
/// <param name="horizontalInput"></param> <param name="verticalInput"></param> <param name="currentMovement"></param> <param name="deltaTime"></param>
	public Vector3 CalculateMovement(Vector3 currentMovement, float horizontalInput, float verticalInput, float deltaTime)
    {
		currentMovement.x = horizontalInput * speed;
        currentMovement.y = verticalInput * speed;;
		return currentMovement;
	}

    /// <summary>
    /// Default Interface to handle collision events between Colliders, Triggers and CharacterControllers
    /// passed down by Move
    /// </summary>
    public void collide(GameObject other)
    {

    }


}
