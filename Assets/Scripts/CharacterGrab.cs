using UnityEngine;
using System.Collections;

public class CharacterGrab : MonoBehaviour
{
	CharacterBehaviour character;
	[SerializeField] float edgeTolerance = .5f;

	void Awake()
	{
		character = GetComponentInParent<CharacterBehaviour>();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(transform.position.y - other.bounds.max.y <= edgeTolerance)
		{
			character.Grab (other);
		}
	}
}
