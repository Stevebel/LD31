﻿using UnityEngine;
using System.Collections;

public class FadeOnCollision : MonoBehaviour {
	private Collider2D _collider;
	private Material _material;
	public int fadeFrames = 60;
	private float fadeProgress;
	private bool fading = false;
	// Use this for initialization
	void Start () {
		_collider = collider2D;
		_material = renderer.sharedMaterial;
	}
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			//_collider.enabled = false;
			fadeProgress = 0f;
			fading = true;
		}
	}
	// Update is called once per frame
	void Update () {
		if(fading){
			if(fadeProgress < 1f){
				fadeProgress +=  1f/fadeFrames;
				_material.SetFloat("_BrightnessOffset", Mathf.Lerp(0,-1,fadeProgress));
			}else{
				Destroy(gameObject);
			}
		}
	}
}
