﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterBehaviour : MonoBehaviour
{
	[SerializeField] protected float xMaxSpeed = 10f;
	[SerializeField] protected float yMaxSpeed = 10f;
	[SerializeField] protected float xAccel = 10f;
	[SerializeField] protected float xDeccel = 20f;
	[SerializeField] protected float xAirAccel = 5f;
	[SerializeField] protected float xAirDeccel = 10f;


	[SerializeField] float minJumpVelocity = 10f;
	[SerializeField] float maxJumpVelocity = 40f;
	[SerializeField] float floatVelocity = 10f;

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
	[SerializeField] float xWallJumpVelocity = 10f;
	[SerializeField] float yWallJumpVelocity = 15f;
	[SerializeField] float wallJumpTime = .1f;
	float wallJumpStartTime = 0f;
	bool lefted;
	bool righted;

	Collider2D leftGrab;
	Collider2D rightGrab;
	[SerializeField] float pullUpVelocity = 15f;
	bool hanging;

	bool facingRight = true;

	public Animator anim;
	Transform sprite;
	float gravityScale;

	[SerializeField] int maxHealth = 1;
	int health;

	bool jumping;

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
		jumping = false;
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround).Length > 0;
		lefted = Physics2D.OverlapCircleAll(leftWallCheck.position, wallRadius, whatIsWall).Length > 0;
		righted = Physics2D.OverlapCircleAll(rightWallCheck.position, wallRadius, whatIsWall).Length > 0;

		if(wallJumpStartTime != 0f && Time.time - wallJumpStartTime >= wallJumpTime)
		{
			airControl = saveAirControl;
			wallJumpStartTime = 0f;
		}
		if(grounded)
			jumping = false;

		if(grounded && hanging)
		{
			hanging = false;
			//Animation stuff
		}

		var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		if (!GeometryUtility.TestPlanesAABB (planes, gameObject.collider2D.bounds)) {
				Die ();
		}

	}

	void Update()
	{
		if(health <= 0)
			Die();
	}

	public void Move(float horiz, float vert, bool crouch, bool jump, bool newJump)
	{
		if(grounded)
		{
			horiz = (crouch ? horiz * crouchSpeed : horiz);
			if(horiz == 0)
				rigidbody2D.velocity = new Vector2(0f, rigidbody2D.velocity.y);
			else if(horiz * rigidbody2D.velocity.x > 0)
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + horiz * xAccel, rigidbody2D.velocity.y);
			else
			{
				Vector2 velocity = new Vector2(rigidbody2D.velocity.x + horiz * xDeccel, rigidbody2D.velocity.y);
				if(velocity.x * rigidbody2D.velocity.x < 0)
					velocity.x = 0;
				rigidbody2D.velocity = velocity;
			}

		}
		else if(airControl && horiz != 0 && !hanging)
		{
			if(horiz * rigidbody2D.velocity.x > 0)
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x + horiz * xAirAccel, rigidbody2D.velocity.y);
			else
			{
				Vector2 velocity = new Vector2(rigidbody2D.velocity.x + horiz * xAirDeccel, rigidbody2D.velocity.y);
				if(velocity.x * rigidbody2D.velocity.x < 0)
					velocity.x = 0;
				rigidbody2D.velocity = velocity;
			}
		}

		bool jumpAnim = false;

		if(jump)
		{
			if(hanging)
			{
				rigidbody2D.velocity = new Vector2(0f, pullUpVelocity);
				hanging = false;
				rigidbody2D.gravityScale = gravityScale;
				jumping = false;
			}
			else if(grounded)
			{
				float jumpVelocity = maxJumpVelocity;//Mathf.Lerp (minJumpVelocity, maxJumpVelocity, jumpPercent);
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpVelocity);
				jumpAnim = true;
				jumping = true;
				//Debug.Log (jumpForce);
			}
			else if(lefted ^ righted && ! jumping)
			{
				Vector2 jumpVelocity = new Vector2(xWallJumpVelocity, yWallJumpVelocity);
				if(righted)
					jumpVelocity.x *= 	-1;
				rigidbody2D.velocity = jumpVelocity;
				wallJumpStartTime = Time.time;
				airControl = false;
				Flip ();
				jumping = false;
				//Debug.Log (jumpForce);
			}
			else if(jumping && rigidbody2D.velocity.y < floatVelocity)
			{
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, floatVelocity);
				Debug.Log (newJump);
			}
			Debug.Log (rigidbody2D.velocity.y);
			if(newJump)
				jumping = false;
		}

		if(rigidbody2D.velocity.y < 0)
			rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -xMaxSpeed, xMaxSpeed), Mathf.Clamp(rigidbody2D.velocity.y, -yMaxSpeed, yMaxSpeed));
		else
			rigidbody2D.velocity = new Vector2(Mathf.Clamp(rigidbody2D.velocity.x, -xMaxSpeed, xMaxSpeed), rigidbody2D.velocity.y);
		float velocityX = Mathf.Abs (rigidbody2D.velocity.x);
		if(velocityX == 0)
			velocityX = -1;
		anim.SetBool ("Jump", jumpAnim);
		anim.SetFloat ("Velocity", velocityX);
		anim.SetBool ("Grounded", grounded);
		
		if(horiz > 0 != facingRight && horiz != 0)
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
		LevelController.instance.Respawn ();
	}
}
