using UnityEngine;
using System.Collections;

public class WordPlatform : MonoBehaviour {

	public Font textFont;
	private TextMesh tMesh;
	public Material fontMaterial;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitializeText(string word){

		tMesh = (TextMesh)this.gameObject.AddComponent ("TextMesh");
		tMesh.font = textFont;
		tMesh.text = word;
		tMesh.characterSize = 1f;

		tMesh.color = Color.white;

		//bCollider = (BoxCollider2D)this.gameObject.AddComponent ("BoxCollider2D");
		BoxCollider2D bCollider = (this.gameObject.collider2D as BoxCollider2D);
		bCollider.size = new Vector2 (gameObject.renderer.bounds.size.x, gameObject.renderer.bounds.size.y * .55f);
		bCollider.center = bCollider.center += new Vector2 (bCollider.size.x / 2, -bCollider.size.y);
		Material m = textFont.material;
		renderer.material = m;
	}

	public void InitializeText(string word, float charSize){
		
		tMesh = (TextMesh)this.gameObject.AddComponent ("TextMesh");
		tMesh.font = textFont;
		tMesh.text = word;
		tMesh.characterSize = charSize;
		
		tMesh.color = Color.white;
		
		//bCollider = (BoxCollider2D)this.gameObject.AddComponent ("BoxCollider2D");
		BoxCollider2D bCollider = (this.gameObject.collider2D as BoxCollider2D);
		bCollider.size = new Vector2 (gameObject.renderer.bounds.size.x, gameObject.renderer.bounds.size.y * .55f);
		bCollider.center = bCollider.center += new Vector2 (bCollider.size.x / 2, -bCollider.size.y);
		Material m = textFont.material;
		renderer.material = m;

	}

	public void setPosition(Vector2 position){
		this.transform.position = position;
	}

	public void setColor(Color c){
		tMesh.color = c;
	}

	public void setBrightness(float x){
		renderer.material.SetFloat ("Brightness Offset", x);
	}

	public void setTint(Color c){
		renderer.material.SetColor ("Tint", c);
	}

	public void setContrast(float c){
		renderer.material.SetFloat ("Contrast Offset", c);
	}

	public void setTextSize(float charSize){
		tMesh.characterSize = charSize;
		BoxCollider2D bCollider = (this.gameObject.collider2D as BoxCollider2D);
		bCollider.size = new Vector2 (gameObject.renderer.bounds.size.x, gameObject.renderer.bounds.size.y * .55f);
		bCollider.center = bCollider.center += new Vector2 (bCollider.size.x / 2, -bCollider.size.y);
	}


}
	                 