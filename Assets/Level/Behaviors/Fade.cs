using UnityEngine;
using System.Collections;

public abstract class Fade : MonoBehaviour {
	private Material _material;
	public int fadeFrames = 30;
	protected float fadeProgress = 0f;
	protected bool fading = false;
	// Use this for initialization
	void Start () {
		_material = renderer.sharedMaterial;
	}
	// Update is called once per frame
	void Update () {
		InnerUpdate ();
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

	abstract public void InnerUpdate();
}
