using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterBehaviour))]
public class PlayerController : MonoBehaviour
{
	private CharacterBehaviour character;
	private float jumpTime;
	private float jumpStartTime = 0f;
	[SerializeField] float maxJumpTime = 0.1f;
	bool stasis;
	bool firstTime;
	VisibilityDetector visibility;

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
	}

	void Update()
	{
		if(Input.GetButtonDown ("Jump"))
		{
			if(jumpStartTime == 0f)
				jumpStartTime = Time.time;
		}
		else if((Input.GetButtonUp ("Jump") || Time.time - jumpStartTime >= maxJumpTime) && jumpStartTime != 0f)
		{
			jumpTime = Mathf.Clamp (Time.time - jumpStartTime, 0f, maxJumpTime);
			jumpStartTime = 0f;
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
			character.Move(h, 0f, false, jumpTime / maxJumpTime);
		jumpTime = 0f;
	}

	public void SetStasis(bool s)
	{
		stasis = s;
		rigidbody2D.isKinematic = s;
	}
}
