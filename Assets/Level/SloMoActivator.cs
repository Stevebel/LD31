using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class SloMoActivator : MonoBehaviour
{
	[SerializeField] DramaticSloMo slomo;

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collide");
		if(collision.collider.tag == "Player")
			slomo.Activate ();
	}
}
