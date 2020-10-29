using UnityEngine;

public class Player : MonoBehaviour
{
	public float yOffset = 6f;
	// Movementspeed
	public float speed = 6;
	// How high we can jump
	public float jumpForce = 11;
	// We save gravity internally
	public float gravity = 20;
	public float slingshotOffset = 15.5f;
	// Distance to "mouseobject" whihc is used for the slingshot as reference
	float distance;

	// How far away the camera should be
	float localCamOffsetZ = 7f;

	// Our Velocity which is needed by other objects
	public Vector3 velocity;
	// contains information to whether or not the character touched
	// ground at the last frame
	protected bool grounded = true;
	protected bool defeated = false;

	protected bool inMenu;
	// Movement is done by Unitys ChracterController
	protected CharacterController controller;
	private Slingshot slingshot;

	// This empty object is used for the slinghshot as reference on the Plane
	public GameObject mousePositionObject;

	// Plane is needed as a 2D reference for the slingshot
	Plane plane;

	Vector3 worldPosition ;


	public void Start()
    {
		// init all needed variables
        controller = GetComponent<CharacterController>();
		slingshot = GetComponent<Slingshot>();
		mousePositionObject =  MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Ziel"));
		plane = new Plane(Vector3.up, transform.position);
		if(mousePositionObject.GetComponent<Collider>() != null)
		{
			mousePositionObject.GetComponent<Collider>().enabled = false;
		}
    }

    void Update()
	{
		Move(Input.GetAxis("Horizontal"), Input.GetButtonDown("Jump"));
		Shoot();
		MoveCamera();
	}
	// Getter
	public CharacterController GetController()
	{
		return controller;
	}
	// Handle Movement as calculated by CalculateMovement()
	public void Move(float horizontalInput, bool jumpPressed)
    {
		// This makes sure that the player does not move onto the Z axis
		Vector3 adjuestedPos = transform.position;
		adjuestedPos.z = 0f;
		transform.position = adjuestedPos;
		// https://docs.unity3d.com/ScriptReference/CharacterController-isGrounded.html
		// isGrounded returns a Boolan of whether or not the character touched
		// the ground last frame
		grounded = controller.isGrounded;
		// Handle Movement
		Turnaround(horizontalInput);
		velocity = controller.velocity;
		velocity = CalculateMovement(velocity, horizontalInput, jumpPressed, Time.deltaTime);
		controller.Move(velocity * Time.deltaTime);
	}

	private void Turnaround(float horizontalInput)
    {
		if (horizontalInput < 0)
		{
			transform.GetChild(0).GetChild(0).localScale = new Vector3(-1, 1, 1);
		}
		else if(horizontalInput > 0)
		{
			transform.GetChild(0).GetChild(0).localScale = new Vector3(1, 1, 1);
		}
	}

	private void Shoot()
    {
		var plane = new Plane(Vector3.down,0);
		// These calculations are done to pass a object onto the slingshot.shootProjectile() function
		// such that a solid direction can be calculated for the projectile

		Vector3 betterPos = transform.position;
		Vector3 mousePos = Input.mousePosition;
		// this number depends both on our transformation of the camera and
		// its static global z-position (-10)
		mousePos.z = Camera.main.nearClipPlane;
		Vector3 mousePos2 = Camera.main.ScreenToWorldPoint(mousePos);
		var ray  = Camera.main.ScreenPointToRay(Input.mousePosition);


		if(plane.Raycast(ray, out distance)){
			var hitPoint = ray.GetPoint(distance);
			// Debug.Log(distance);
			
			hitPoint.Normalize();
			mousePositionObject.transform.position = transform.position + new Vector3(hitPoint.x, hitPoint.z, 0f) * 2.5f;
		}


		if (Input.GetButtonDown("Fire1"))
		{
			GameObject shot = slingshot.shootProjectile(mousePositionObject);
		}
	}

	public void MoveCamera()
    {
		// Make sure the camera stays behind us
		transform.Find("Camera").localPosition = new Vector3(0, 3.7f - transform.position.y, -localCamOffsetZ);
	}
	// Calculate movement based on whether we pressed the jump button, the direction the player wants to walk
	// and the time passed
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
	//Getter
	public bool getGrounded()
	{
		return grounded;
	}
	//Setter
	public void setGrounded(bool newGrounding)
	{
		grounded = newGrounding;
	}
	// Getter
	public float getGravity()
	{
		return gravity;
	}
	// This triggers our Collision Interface
	// When colliding with an enemy we die
	// When collidion with an Mushroom we jump
	public void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.tag == "Enemy")
		{
    		hit.transform.SendMessage("collide", this.gameObject);
			collide(hit.gameObject);
		}
		if(hit.gameObject.GetComponent<MushroomJump>() != null)
		{
			if(hit.gameObject.transform.position.y < transform.position.y-2f)
				hit.transform.gameObject.GetComponent<MushroomJump>().SendMessage("Collide", this.gameObject);
		}

 	}
	public void OnTriggerEnter(Collider collider)
    {
		collide(collider.gameObject);
	}

	// Common Collision Interface
	public void collide(GameObject other)
	{
		if(other.tag == "Enemy")
		{
			defeat();
		}
	}
	// When we are not in any menu and we die
	// We are defeated
	public void defeat()
	{
		if(!inMenu)
		{
			GameManager.GetInstance().PlayerDefeated();
			defeated = true;
			setInMenu(true);
			controller.enabled = false;
		}
	}
	public void setInMenu(bool newInMenu)
	{
		inMenu = newInMenu;
	}
	public bool getInMenu()
	{
		return inMenu;
	}
	public bool getDefeated()
    {
		return defeated;
    }
}