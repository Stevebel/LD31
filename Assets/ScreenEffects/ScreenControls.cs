using UnityEngine;
using System.Collections;

public class ScreenControls : MonoBehaviour {
	public BarControl screenBar;
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
			ChangeBrightness(1);
			break;
		case "BrightnessDown":
			ChangeBrightness(-1);
			break;
		}
	}

	void ChangeBrightness(int direction){
		float value = (effects.brightness + 1)/2f;
		value = Mathf.Clamp01(value + (1f/16f * direction));
		effects.brightness = (value * 2) - 1;
		screenBar.DisplayBar("Brightness", value);
	}
}
