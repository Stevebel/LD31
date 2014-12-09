using UnityEngine;
using System.Collections;

public class DuplicateMaterial : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Material m = renderer.material;
		renderer.material = m;
		EffectController.instance.AddMaterial(m);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
