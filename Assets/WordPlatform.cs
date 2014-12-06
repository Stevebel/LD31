using UnityEngine;
using System.Collections;

public class WordPlatform : MonoBehaviour {

	public Font textFont;
	TextMesh tMesh;
	BoxCollider2D bCollider;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeText(string word){

		tMesh = (TextMesh)this.gameObject.AddComponent ("TextMesh");
		tMesh.font = textFont;
		tMesh.text = word;
		tMesh.characterSize = 1;

		tMesh.color = Color.black;

		bCollider = (BoxCollider2D)this.gameObject.AddComponent ("BoxCollider2D");
		this.gameObject.AddComponent("MeshRenderer");
		gameObject.renderer.material = textFont.material;

		Rigidbody2D rg = (Rigidbody2D)this.gameObject.AddComponent ("Rigidbody2D");

		rg.isKinematic = true;
		rg.gravityScale = 0;
		rg.fixedAngle = true;
	}
}
	                 