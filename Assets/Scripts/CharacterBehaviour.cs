using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterBehaviour : MonoBehaviour
{
	[SerializeField] protected float xMaxSpeed = 10f;
	[SerializeField] protected float yMaxSpeed = 10f;

	[SerializeField] float minJumpForce = 100f;
	[SerializeField] float maxJumpForce = 400f;

	[Range(0, 1)]
	[SerializeField] float crouchSpeed = .36f;

	[SerializeField] bool airControl = false;
	bool saveAirControl;
	[SerializeField] LayerMask whatIsGround;
	[SerializeField] LayerMask whatIsWall;

	Transform groundCheck;
	float groundedRadius = .2f;
	[SerializeField] bool grounded = false;
	Transform ceilingCheck;
	float ceilingRadius = .2f;

	Transform leftWallCheck;
	Transform rightWallCheck;
	float wallRadius = .2f;
	[SerializeField] float wallJumpAngle = .78f;
	[SerializeField] float wallJumpForce = 400f;
	[SerializeField] float wallJumpTime = .1f;
	float wallJumpStartTime = 0f;
	bool lefted;
	bool righted;

	Collider2D leftGrab;
	Collider2D rightGrab;
	[SerializeField] float pullUpForce = 400f;
	bool hanging;

	bool facingRight = true;

	public Animator anim;
	Transform sprite;
	float gravityScale;

	[SerializeField] int maxHealth = 1;
	int health;

	void Awake()
	{
		groundCheck = transform.Find ("GroundCheck");
		ceilingCheck = transform.Find ("CeilingCheck");
		leftWallCheck = transform.Find ("LeftWallCheck");
		rightWallCheck = transform.Find ("RightWallCheck");
		anim = GetComponent<Animator>();	
		saveAirControl = airControl;
		wallJumpStartTime = 0f;
		sprite = transform.Find ("PlayerSprite").GetComponent<Transform>();
		leftGrab = transform.Find ("LeftGrabCheck").GetComponent<Collider2D>();
		rightGrab = transform.Find ("RightGrabCheck").GetComponent<Collider2D>();
		hanging = false;
		gravityScale = rigidbody2D.gravityScale;
		health = maxHealth;
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround).Length > 0;
		lefted = Physics2D.OverlapCircleAll(leftWallCheck.position, wallRadius, whatIsWall).Length > 0;
		righted = Physics2D.OverlapCircleAll(rightWallCheck.position, wallRadius, whatIsWall).Length > 0;
		//Debug.Log (lefted);

		if(wallJumpStartTime != 0f && Time.time - wallJumpStartTime >= wallJumpTime)
		{
			airControl = saveAirControl;
			wallJumpStartTime = 0f;
		}

		if(grounded && hanging)
		{
			hanging = false;
			//Animation stuff
		}
	}

	void Update()
	{
		if(health <= 0)
			Die();
	}

	public void Move(float horiz, float vert, bool crouch, float jumpPercent)
	{
		if(grounded)
		{
			horiz = (crouch ? horiz * crouchSpeed : horiz);
			rigidbody2D.velocity = new Vector2(horiz * xMaxSpeed, rigidbody2D.velocity.y + vert * yMaxSpeed);
		}
		else if(airControl && horiz != 0 && !hanging)
		{
			rigidbody2D.velocity = new Vector2(horiz * xMaxSpeed, rigidbody2D.velocity.y + vert * yMaxSpeed);
		}

		if(jumpPercent != 0f)
		{
			if(hanging)
			{
				rigidbody2D.AddForce (new Vector2(0f, pullUpForce));
				hanging = false;
				rigidbody2D.gravityScale = gravityScale;
			}
			else if(grounded)
			{
				float jumpForce = Mathf.Lerp (minJumpForce, maxJumpForce, jumpPercent);
				rigidbody2D.AddForce(new Vector2(0f, jumpForce));
				//Debug.Log (jumpForce);
			}
			else if(lefted ^ righted)
			{
				Vector2 jumpForce = new Vector2(wallJumpForce * Mathf.Cos (wallJumpAngle), wallJumpForce * Mathf.Sin (wallJumpAngle));
				if(righted)
					jumpForce.x *= 	-1;
				rigidbody2D.velocity = Vector2.zero;
				rigidbody2D.AddForce (jumpForce);
				wallJumpStartTime = Time.time;
				airControl = false;
				//Debug.Log (jumpForce);
			}
		}

		if(horiz > 0 != facingRight)
			Flip();
	}

	public bool IsGrounded()
	{
		return grounded;
	}

	void Flip()
	{
		if(rigidbody2D.velocity.x > 0 && !facingRight || rigidbody2D.velocity.x < 0 && facingRight)
		{
			facingRight = !facingRight;
			Vector3 scale = sprite.localScale;
			scale.x *= -1;
			sprite.localScale = scale;
		}
	}

	public void Attack()
	{
		//Animator stuff
	}

	public void Grab(Collider2D other)
	{
		if(grounded || hanging || rigidbody2D.velocity.y > 0)
			return;

		hanging = true;
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.gravityScale = 0;
		//Animation stuff
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Attack")
			health--;
	}

	void Die()
	{
	}
}
