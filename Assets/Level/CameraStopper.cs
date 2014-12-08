using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class CameraStopper : MonoBehaviour
{
	void OnBecameVisible()
	{
		if(!Switches.IsOn (0))
			CameraController.instance.shouldScroll = false;
	}
}
