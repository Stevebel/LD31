using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class SloMoActivator : MonoBehaviour
{
	[SerializeField] DramaticSloMo slomo;

	void OnCollision2D(Collision2D collision)
	{
		if(collision.collider.tag == "Player")
			slomo.Activate ();
	}
}
