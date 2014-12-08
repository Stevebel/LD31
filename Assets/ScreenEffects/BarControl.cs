using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarControl : MonoBehaviour {
	public Image filledImage;
	public Image emptyImage;
	public Text label;
	private float multiplier = 60;
	private int maxValue = 32;

	private int timeout = 60;
	private int timeLeft = 0;
	// Use this for initialization
	void Start () {
		label.text = "???";
		filledImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,0);
	}
	private int oldSetting = 0;
	public void DisplayBar(string name, float value){
		StartTimeout();
		label.text = name;

		int setting = Mathf.FloorToInt(Mathf.Clamp01(value) * maxValue);
		if(oldSetting != setting){
			filledImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,setting * multiplier);
			oldSetting = setting;
		}
	}
	private void StartTimeout(){
		timeLeft = timeout;
		label.enabled = filledImage.enabled = emptyImage.enabled = true;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(timeLeft == 0){
			label.enabled = filledImage.enabled = emptyImage.enabled = false;
		}
		timeLeft--;
	}
}
