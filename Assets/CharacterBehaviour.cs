using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterBehaviour : MonoBehaviour
{
	[SerializeField] protected float xMaxSpeed = 10f;
	[SerializeField] protected float yMaxSpeed = 10f;

	[SerializeField] float jumpForce = 40f;

	[Range(0, 1)]
	[SerializeField] float crouchSpeed = .36f;

	[SerializeField] bool airControl = false;
	[SerializeField] LayerMask whatIsGround;

	[SerializeField]Transform groundCheck;
	float groundedRadius = 2f;
	[SerializeField] bool grounded = false;
	Transform ceilingCheck;
	float ceilingRadius = .01f;
	public Animator anim;

	void Awake()
	{
		groundCheck = transform.Find ("GroundCheck");
		ceilingCheck = transform.Find ("CeilingCheck");
		anim = GetComponent<Animator>();	
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround).Length > 0;
	}

	public void Move(float horiz, float vert, bool crouch, bool jump)
	{
		if(grounded || airControl)
		{
			horiz = (crouch ? horiz * crouchSpeed : horiz);
			rigidbody2D.velocity = new Vector2(horiz * xMaxSpeed, rigidbody2D.velocity.y + vert * yMaxSpeed);
		}

		if(grounded && jump)
		{
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
	}
}
