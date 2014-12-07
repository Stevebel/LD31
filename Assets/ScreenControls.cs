using UnityEngine;
using System.Collections;

public class ScreenControls : MonoBehaviour {
	private EffectController effects;
	// Use this for initialization
	void Start () {
		effects = GetComponent<EffectController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnButtonPressed(string button){
		Debug.Log("Pressed " + button);
		switch(button){
		case "BrightnessUp":
			effects.brightness += 0.1f;
			break;
		case "BrightnessDown":
			effects.brightness -= 0.1f;
			break;
		}
	}
}
