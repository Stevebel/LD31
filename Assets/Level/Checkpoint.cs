using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Checkpoint : MonoBehaviour
{
	public static Checkpoint current;

	void OnBecameVisible()
	{
		Debug.Log ("hola");
		current = this;
		Debug.Log (Checkpoint.current.transform.position);
	}
}
