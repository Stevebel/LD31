using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour
{
	Animator anim;
	[SerializeField] float delay = 2f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();	
	}


	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.gameObject.tag.Equals("Player"))
			anim.SetBool("Flipped",true);
	}

	void Die()
	{
		StartCoroutine("CoDie");
	}
	IEnumerator CoDie()
	{
		float startTime = Time.time;
		for(float current = startTime; current - startTime < delay; current += Time.deltaTime /Time.timeScale)
			yield return null;
		Switches.SwitchOn (Switches.SWITCH.LEVER_ACTIVATED);
		CameraController.instance.shouldScroll = true;
		DramaticSloMo.slomo.Deactivate ();
	}
}
