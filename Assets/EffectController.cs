using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour {
	[SerializeField]
	private Material _controlledMaterial;
	[Range(0,1)]
	public float red = 1;
	[Range(0,1)]
	public float green = 1;
	[Range(0,1)]
	public float blue = 1;
	[Range(0,1)]
	public float brightness = 0;
	[Range(-1,1)]
	public float contrast = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_controlledMaterial.SetColor("_Color", new Color(red,green,blue));
		_controlledMaterial.SetFloat("_Brightness",brightness);
		_controlledMaterial.SetFloat("_Contrast",contrast);
	}
}
