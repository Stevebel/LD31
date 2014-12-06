using UnityEngine;
using System.Collections;

public class VisibilityDetector : MonoBehaviour {
	public float cutoff = 0.1f;
	public Color activeColor = new Color(1,1,1,1);
	public Material spriteMaterial;
	[SerializeField][ReadOnlyAttribute]
	private float _luminosity = 0f;
	[SerializeField][ReadOnlyAttribute]
	private bool _isVisible = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float filterLum = (activeColor.r + activeColor.g + activeColor.b);

		float brightness = spriteMaterial.GetFloat("_Brightness");
		float brightnessOffset = spriteMaterial.GetFloat("_BrightnessOffset");
		Color color = spriteMaterial.GetColor("_Color");
		Color tint = spriteMaterial.GetColor("_Tint");

		Color outcome = color * tint * activeColor;
		_luminosity = (outcome.r + outcome.g + outcome.b) / filterLum;
		_luminosity += brightness + brightnessOffset;

		_isVisible = _luminosity > cutoff;
	}
}
