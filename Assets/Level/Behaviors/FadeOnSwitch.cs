using UnityEngine;
using System.Collections;

public class FadeOnSwitch : MonoBehaviour {
	public Switches.SWITCH targetSwitch = Switches.SWITCH.LEVER_ACTIVATED;
	private Material _material;
	public int fadeFrames = 15;
	private float fadeProgress = 0f;
	private bool fading = false;
	// Use this for initialization
	void Start () {
		_material = renderer.sharedMaterial;
	}
	// Update is called once per frame
	void Update () {
		if(Switches.IsOn(targetSwitch)){
			fading = true;
		}
		if(fading){
			if(fadeProgress < 1f){
				fadeProgress +=  1f/fadeFrames;
				if(_material != null){
					_material.SetFloat("_BrightnessOffset", Mathf.Lerp(0,-1,fadeProgress));
				}
			}else{
				Destroy(gameObject);
			}
		}
	}
}

