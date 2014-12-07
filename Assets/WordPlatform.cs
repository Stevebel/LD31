﻿using UnityEngine;
using System.Collections;

public class WordPlatform : MonoBehaviour {

	public Font textFont;
	public PhysicsMaterial2D platformMaterial;
	private TextMesh tMesh;
	//private BoxCollider2D bCollider;

	// Use this for initialization
	void Start () {
		InitializeText ("Test");
		setPosition (-2, -5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitializeText(string word){

		tMesh = (TextMesh)this.gameObject.AddComponent ("TextMesh");
		tMesh.font = textFont;
		tMesh.text = word;
		tMesh.characterSize = 1f;

		tMesh.color = Color.black;

		//bCollider = (BoxCollider2D)this.gameObject.AddComponent ("BoxCollider2D");
		BoxCollider2D bCollider = (this.gameObject.collider2D as BoxCollider2D);
		bCollider.size = new Vector2 (gameObject.renderer.bounds.size.x, gameObject.renderer.bounds.size.y * .55f);
		bCollider.center = bCollider.center += new Vector2 (bCollider.size.x / 2, -bCollider.size.y);
		//this.gameObject.AddComponent("MeshRenderer");
		gameObject.renderer.material = textFont.material;

		Rigidbody2D rg = (Rigidbody2D)this.gameObject.AddComponent ("Rigidbody2D");

		rg.isKinematic = true;
		rg.gravityScale = 0;
		rg.fixedAngle = true;
	}

	public void setPosition(float x, float y){
		this.transform.position = new Vector2 (x, y);
		}


}
	                 