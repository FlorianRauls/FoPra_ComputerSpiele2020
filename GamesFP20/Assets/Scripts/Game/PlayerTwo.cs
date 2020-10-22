using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : Player
{

    // Start is called before the first frame update
    public new void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        // Makes sure that the player stays at the same position at Z axis
		Vector3 adjuestedPos = transform.position;
		adjuestedPos.z = 0f;
		transform.position = adjuestedPos;
        // Movement logic
		grounded = controller.isGrounded;
        Move(Input.GetAxis("HorizontalTwo"), Input.GetButtonDown("JumpTwo"));

    }
}
