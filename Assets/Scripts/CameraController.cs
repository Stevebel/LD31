using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public bool shouldScroll;
	[SerializeField] float speed = 2f;

	// Use this for initialization
	void Start ()
	{
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
