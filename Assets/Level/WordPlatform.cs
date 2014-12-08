using UnityEngine;
using System.Collections;

public class WordPlatform : MonoBehaviour {

	public Font textFont;
	private TextMesh tMesh;
	public Material fontMaterial;
	public EffectController effectController;

	// Use this for initialization
	void Start () {
		hideFlags = HideFlags.HideAndDontSave;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitializeText(string word){
		InitializeText(word, 1f);
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
		bCollider.center = new Vector2 (bCollider.size.x / 2, -bCollider.size.y);
		Material m = Instantiate(fontMaterial) as Material;
		renderer.material = m;
		effectController.AddMaterial(m);
	}

	public void setPosition(Vector2 position){
		this.transform.position = position;
	}

	public void setColor(Color c){
		tMesh.color = c;
	}

	public void setBrightness(float x){
		renderer.sharedMaterial.SetFloat ("_BrightnessOffset", x);
	}

	public void setTint(Color c){
		renderer.sharedMaterial.SetColor ("_Tint", c);
	}

	public void setContrast(float c){
		renderer.sharedMaterial.SetFloat ("_ContrastOffset", c);
	}

	public void setTextSize(float charSize){
		tMesh.characterSize = charSize;
		BoxCollider2D bCollider = (this.gameObject.collider2D as BoxCollider2D);
		bCollider.size = new Vector2 (gameObject.renderer.bounds.size.x, gameObject.renderer.bounds.size.y * .55f);
		bCollider.center = new Vector2 (bCollider.size.x / 2, -bCollider.size.y);
	}


}
	                 