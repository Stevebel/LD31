using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public static CameraController instance;
	public bool shouldScroll;
	[SerializeField] float speed = 0.01f;

	// Use this for initialization
	void Start ()
	{
		instance = this;
		shouldScroll = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if(!shouldScroll)
			return;
		Vector3 position = Camera.main.transform.position;
		position.y -= speed;
		Camera.main.transform.position = position;
	}
}
