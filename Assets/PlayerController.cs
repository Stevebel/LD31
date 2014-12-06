using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterBehaviour))]
public class PlayerController : MonoBehaviour
{
	private CharacterBehaviour character;
	private bool jump;

	void Awake()
	{
		character = GetComponent<CharacterBehaviour>();
	}

	void Update()
	{
		if(Input.GetButtonDown ("Jump"))
			jump = true;
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		character.Move(h, 0, false, jump);
		jump = false;
	}
}
