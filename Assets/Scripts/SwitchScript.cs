using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();	
	}


	void OnTriggerEnter2D(Collider2D c) {
		if(c.gameObject.tag.Equals("Player")){
			anim.SetBool("Flipped",true);
		}
	}

}
