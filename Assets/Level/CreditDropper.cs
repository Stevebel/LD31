using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class CreditDropper : MonoBehaviour
{
	[SerializeField] Rigidbody2D[] credits;
	[SerializeField] float delay = 1f;

	void OnBecameVisible()
	{
		StartCoroutine("Drop");
	}

	IEnumerator Drop()
	{
		float startTime = Time.time;
		while(Time.time - startTime < delay)
			yield return null;
		foreach(Rigidbody2D credit in credits)
			credit.isKinematic = false;
	}
}
