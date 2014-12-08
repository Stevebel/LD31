using UnityEngine;
using System.Collections;

public class DramaticSloMo : MonoBehaviour
{
	public static DramaticSloMo slomo;
	[SerializeField] Transform target;
	[SerializeField] float minScale = .01f;
	float maxDistance;

	void Awake()
	{
		maxDistance = 0;
	}

	void Start()
	{
		slomo = this;
	}

	public void Activate()
	{
		maxDistance = (transform.position - target.position).magnitude;
	}

	// Update is called once per frame
	void Update ()
	{
		if(maxDistance == 0)
			return;
		float distance = (transform.position - target.position).magnitude;
		distance = Mathf.Clamp (distance, 0f, maxDistance) / maxDistance;
		Time.timeScale = Mathf.Lerp (minScale, 1f, distance);
	}
}
