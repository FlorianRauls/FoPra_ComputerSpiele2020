﻿using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 6;
	public float jumpForce = 10;
	public float gravity = 20;
	// contains information to whether or not the character touched
	// ground at the last frame
	private bool grounded = true;
	private CharacterController controller;


	public void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
	{
		// https://docs.unity3d.com/ScriptReference/CharacterController-isGrounded.html
		// isGrounded returns a Boolan of whether or not the character touched
		// the ground last frame
		grounded = controller.isGrounded;
		Move(Input.GetAxis("Horizontal"), Input.GetButtonDown("Jump"));
	}

	public void Move(float horizontalInput, bool jumpPressed)
    {
		Vector3 velocity = controller.velocity;
		velocity = CalculateMovement(velocity, horizontalInput, jumpPressed, Time.deltaTime);
		controller.Move(velocity * Time.deltaTime);
	}

	public Vector3 CalculateMovement(Vector3 currentMovement, float horizontalInput, bool jumpPressed, float deltaTime)
    {
		currentMovement.x = horizontalInput * speed;
		if (jumpPressed)
		{
			// only allow jumping as long as grounded is true to prevent infinite jumping
			if(grounded)
				currentMovement.y = jumpForce;
		}
		currentMovement.y -= gravity * deltaTime;
		return currentMovement;
	}

	public bool getGrounded()
	{
		return grounded;
	}

	public void setGrounded(bool newGrounding)
	{
		grounded = newGrounding;
	}

	public float getGravity()
	{
		return gravity;
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.tag == "Enemy")
    		hit.transform.SendMessage("collide", this.gameObject);
 	}

	public void collide(GameObject other)
	{

	}

	public void defeat()
	{

	}

	public void setDefeated()
	{

	}

	public bool getDefeated()
	{

	}

	public void setInDefeatMenu()
	{

	}

	public bool getInDefeatMenu()
	{

	}

	public void setInAccomplishedMenu()
	{

	}

	public bool getInAccomplishedMenu()
	{

	}

	public void setInLevelMenu(bool newLevelMenuBool)
	{

	}

	public bool getInLevelMenu()
	{

	}

}