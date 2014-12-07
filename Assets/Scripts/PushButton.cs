using UnityEngine;
using System.Collections;

public class PushButton : MonoBehaviour {
	public Sprite upImage;
	public Sprite downImage;
	public string name = "Button";
	public GameObject target;
	public int repeatInterval = 10;
	private SpriteRenderer spriteRenderer;
	private bool pressed = false;
	private int repeatCountdown = 0;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		if(target == null){
			target = gameObject;
		}
	}

	void FixedUpdate(){
		if(pressed){
			if(repeatCountdown-- == 0){
				target.SendMessage("OnButtonPressed", name);
				repeatCountdown = repeatInterval;
			}
		}
	}

	void OnMouseDown()
	{
		pressed = true;
		repeatCountdown = 0;
		spriteRenderer.sprite = downImage;
	}
	
	void OnMouseUp()
	{
		pressed = false;
		spriteRenderer.sprite = upImage;
	}
}
