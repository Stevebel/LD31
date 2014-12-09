using UnityEngine;
using System.Collections;

public class DramaticSloMo : MonoBehaviour
{
	public static DramaticSloMo slomo;
	[SerializeField] Transform target;
	[SerializeField] float minScale = .01f;
	[SerializeField] float maxDistance;
	bool activated;

	void Start()
	{
		slomo = this;
		activated = false;
	}

	public void Activate()
	{
		activated = true;
	}

	public void Deactivate()
	{
		activated = false;
		Time.timeScale = 1f;
	}

	void OnDestroy()
	{
		Deactivate ();
	}

	// Update is called once per frame
	void Update ()
	{
		if(!activated)
			return;
		if(maxDistance == 0)
			return;
		float distance = (transform.position - target.position).magnitude;
		distance = Mathf.Clamp (distance, 0f, maxDistance) / maxDistance;
		Time.timeScale = Mathf.Lerp (minScale, 1f, distance);
	}
}
