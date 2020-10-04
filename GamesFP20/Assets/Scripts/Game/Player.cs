using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 6;
	public float jumpForce = 11;
	public float gravity = 20;
	float distance;

	public Vector3 velocity;
	// contains information to whether or not the character touched
	// ground at the last frame
	private bool grounded = true;

	private bool defeated = false;
	private bool inLevelMenu;
	private bool inAccomplishedMenu;
	private bool inDefeatedMenu;
	
	private CharacterController controller;
	private Slingshot slingshot;

	public GameObject mousePositionObject;

	Plane plane;

	Vector3 worldPosition ;


	public void Start()
    {
        controller = GetComponent<CharacterController>();
		slingshot = GetComponent<Slingshot>();
		mousePositionObject = new GameObject();
		plane = new Plane(Vector3.up, 0);
    }

    void Update()
	{
		Vector3 adjuestedPos = transform.position;
		adjuestedPos.z = 0f;
		transform.position = adjuestedPos;
		// https://docs.unity3d.com/ScriptReference/CharacterController-isGrounded.html
		// isGrounded returns a Boolan of whether or not the character touched
		// the ground last frame
		grounded = controller.isGrounded;
		Move(Input.GetAxis("Horizontal"), Input.GetButtonDown("Jump"));

		Debug.Log(Input.mousePosition);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (plane.Raycast(ray, out distance))
		{
			worldPosition= ray.GetPoint(distance);
		}

		mousePositionObject.transform.position = worldPosition;
    

		if(Input.GetButtonDown("Fire1"))
		{
			GameObject shot = slingshot.shootProjectile(mousePositionObject);
		}
		transform.Find("Camera").localPosition = new Vector3(0, 3.7f - transform.position.y, -7);

	}

	public CharacterController GetController()
	{
		return controller;
	}

	public void Move(float horizontalInput, bool jumpPressed)
    {
		velocity = controller.velocity;
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

	void OnTriggerEnter(Collider collider)
    {
		collide(collider.gameObject);
	}

	public void collide(GameObject other)
	{
		if(other.tag == "Enemy")
		{
			defeat();
		}
	}

	public void defeat()
	{
		if(!getInAccomplishedMenu() & !getInLevelMenu())
		{
			setDefeated(true);
			setInDefeatMenu(true);
			controller.enabled = false;
		}
	}

	public void setDefeated(bool newDefeated)
	{
		defeated = newDefeated;
	}

	public bool getDefeated()
	{
		return defeated;
	}

	public void setInDefeatMenu(bool newInDefeatMenu)
	{
		inDefeatedMenu = newInDefeatMenu;
	}

	public bool getInDefeatMenu()
	{
		return inDefeatedMenu;
	}

	public void setInAccomplishedMenu(bool newInAccomplishedMenu)
	{
		inAccomplishedMenu = newInAccomplishedMenu;
	}

	public bool getInAccomplishedMenu()
	{
		return inAccomplishedMenu;
	}

	public void setInLevelMenu(bool newLevelMenuBool)
	{
		inLevelMenu = newLevelMenuBool;
	}

	public bool getInLevelMenu()
	{
		return inLevelMenu;
	}

}