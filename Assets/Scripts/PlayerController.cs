using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterBehaviour))]
public class PlayerController : MonoBehaviour
{
	private CharacterBehaviour character;
	private float jumpTime;
	private float jumpStartTime = 0f;
	bool jump;
	[SerializeField] float maxJumpTime = 0.1f;
	bool stasis;
	bool firstTime;
	VisibilityDetector visibility;
	bool stillJumping;

	void Awake()
	{
		firstTime = true;
	}

	void Start()
	{
		character = GetComponent<CharacterBehaviour>();
		stasis = true;
		rigidbody2D.isKinematic = true;
		visibility = GetComponent<VisibilityDetector>();
		stillJumping = false;
		jump = false;
	}

	void Update()
	{
		if(Input.GetButtonDown ("Jump"))
		{
			if(jumpStartTime == 0f)
				jumpStartTime = Time.time;
			jump = true;
		}
		else if(Input.GetButton ("Jump"))
			stillJumping = true;
		if(Input.GetButtonUp ("Jump") || Time.time - jumpStartTime >= maxJumpTime && jumpStartTime != 0f)
		{
			jumpTime = Mathf.Clamp (Time.time - jumpStartTime, 0f, maxJumpTime);
			jumpStartTime = 0f;
			stillJumping = false;
			jump = false;
		}

		if(Input.GetButtonDown ("Fire1"))
			character.Attack();

		if(firstTime && visibility.GetVisible())
		{
			firstTime = false;
			SetStasis (false);
			CameraController.instance.shouldScroll = true;
		}
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		if(!stasis)
			character.Move(h, 0f, false, jump, stillJumping);
		jumpTime = 0f;
	}

	public void SetStasis(bool s)
	{
		stasis = s;
		rigidbody2D.isKinematic = s;
	}
}
