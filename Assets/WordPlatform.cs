using UnityEngine;
using System.Collections;

public class WordPlatform : MonoBehaviour {

	public Font textFont;
	private TextMesh tMesh;
	private BoxCollider2D bCollider;

	// Use this for initialization
	void Start () {
		InitializeText ("Test");
		setPosition (7, 8);
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

		bCollider = (BoxCollider2D)this.gameObject.AddComponent ("BoxCollider2D");
		bCollider.size = new Vector2 (bCollider.size.x, bCollider.size.y * .55f);
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
	                 