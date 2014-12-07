using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterBehaviour))]
public class PlayerController : MonoBehaviour
{
	private CharacterBehaviour character;
	private float jumpTime;
	private float jumpStartTime = 0f;
	[SerializeField] float maxJumpTime = 0.1f;

	void Awake()
	{
		character = GetComponent<CharacterBehaviour>();
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

		if(Input.GetButtonDown ("Attack"))
			character.Attack();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		character.Move(h, 0f, false, jumpTime / maxJumpTime);
		jumpTime = 0f;
	}
}
