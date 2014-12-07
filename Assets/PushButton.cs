using UnityEngine;
using System.Collections;

public class PushButton : MonoBehaviour {
	public Sprite upImage;
	public Sprite downImage;
	public string name = "Button";
	public GameObject target;
	private SpriteRenderer spriteRenderer;
	private Collider2D collider2d;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		collider2d = GetComponent<Collider2D>();
		if(target == null){
			target = gameObject;
		}
	}
	
	void OnMouseDown()
	{
		spriteRenderer.sprite = downImage;
	}
	
	void OnMouseUp()
	{
		target.SendMessage("OnButtonPressed", name);
		spriteRenderer.sprite = upImage;
	}
}
