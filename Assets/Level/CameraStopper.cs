using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class CameraStopper : MonoBehaviour
{
	void OnBecameVisible()
	{
		CameraController.instance.shouldScroll = false;
	}
}
