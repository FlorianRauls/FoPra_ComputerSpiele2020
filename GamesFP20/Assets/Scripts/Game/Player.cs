using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 6;
	public float jumpForce = 10;
	public float gravity = 20;
	private CharacterController controller;

	public void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
	{
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
			currentMovement.y = jumpForce;
		}
		currentMovement.y -= gravity * deltaTime;
		return currentMovement;
	}
}