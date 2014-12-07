using UnityEngine;
using System.Collections;

public class ScreenControls : MonoBehaviour {
	public BarControl screenBar;
	public Camera mainCamera;
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
		case "PositionLeft":
			ChangeHorizontal(-1);
			break;
		case "PositionRight":
			ChangeHorizontal(1);
			break;
		case "PositionUp":
			ChangeVertical(-1);
			break;
		case "PositionDown":
			ChangeVertical(1);
			break;
		case "RedUp":
			ChangeRed(1);
			break;
		case "RedDown":
			ChangeRed(-1);
			break;
		case "GreenUp":
			ChangeGreen(1);
			break;
		case "GreenDown":
			ChangeGreen(-1);
			break;
		case "BlueUp":
			ChangeBlue(1);
			break;
		case "BlueDown":
			ChangeBlue(-1);
			break;
		}
	}

	void ChangeBrightness(int direction){
		float value = (effects.brightness + 1)/2f;
		value = Mathf.Clamp01(value + (1f/16f * direction));
		effects.brightness = (value * 2) - 1;
		screenBar.DisplayBar("Brightness", value);
	}
	void ChangeRed(int direction){
		float value = effects.red;
		value = Mathf.Clamp01(value + (1f/16 * direction));
		effects.red = value;
		screenBar.DisplayBar("Red", value);
	}

	void ChangeGreen(int direction){
		float value = effects.green;
		value = Mathf.Clamp01(value + (1f/16 * direction));
		effects.green = value;
		screenBar.DisplayBar("Green", value);
	}

	void ChangeBlue(int direction){
		float value = effects.blue;
		value = Mathf.Clamp01(value + (1f/16 * direction));
		effects.blue = value;
		screenBar.DisplayBar("Blue", value);
	}

	void ChangeHorizontal(int direction){
		float range = 100f;
		int steps = 32;
		float offset = range/2;
		Vector3 cameraPos = mainCamera.transform.position;
		float value = -(cameraPos.x/range) + 0.5f + (1f/steps * direction);
		value = Mathf.Clamp01(value);
		mainCamera.transform.position = new Vector3(-(value - 0.5f) * range, cameraPos.y,cameraPos.z);
		screenBar.DisplayBar("Horizontal", value);
	}
	void ChangeVertical(int direction){
		float range = 100f;
		int steps = 32;
		float offset = range/2;
		Vector3 cameraPos = mainCamera.transform.position;
		float value = (cameraPos.y/range) + 0.5f + (1f/steps * direction);
		value = Mathf.Clamp01(value);
		mainCamera.transform.position = new Vector3(cameraPos.x,(value - 0.5f) * range,cameraPos.z);
		screenBar.DisplayBar("Vertical", value);
	}
}
