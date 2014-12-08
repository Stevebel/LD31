using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class CameraStopper : MonoBehaviour
{
	[SerializeField] bool careAboutSwitch = false;

	void OnBecameVisible()
	{
		if(!Switches.IsOn (0) || !careAboutSwitch)
			CameraController.instance.shouldScroll = false;
	}
}
