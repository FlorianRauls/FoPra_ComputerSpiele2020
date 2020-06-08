using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 6;
	public float jumpForce = 10;
	public float gravity = 20;
	private CharacterController controller;

	void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
	{
        Vector3 velocity = controller.velocity;

		velocity.x = Input.GetAxis("Horizontal") * speed;

		if (Input.GetButtonDown("Jump"))
		{
			velocity.y = jumpForce;
		}
		
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); 
    }
}