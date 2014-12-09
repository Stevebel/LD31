using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectController : MonoBehaviour {
	public static EffectController instance;
	public List<Material> defaultMaterials;
	private List<Material> _controlledMaterials = new List<Material>();
	[Range(0,1)]
	public float red = 1;
	[Range(0,1)]
	public float green = 1;
	[Range(0,1)]
	public float blue = 1;
	[Range(-1,1)]
	public float brightness = 0;
	[Range(-1,1)]
	public float contrast = 0;
	// Use this for initialization
	void Awake () {
		instance = this;
		_controlledMaterials = defaultMaterials;
	}
	public void AddMaterial(Material mat){
		if(mat != null){
			_controlledMaterials.Add(mat);
		}
	}
	// Update is called once per frame
	void Update () {
		foreach(Material material in _controlledMaterials){
			material.SetColor("_Color", new Color(red,green,blue));
			material.SetFloat("_Brightness",brightness);
			material.SetFloat("_Contrast",contrast);
		}

	}
}
