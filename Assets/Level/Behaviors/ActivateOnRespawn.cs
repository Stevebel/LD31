using UnityEngine;
using System.Collections;

public class ActivateOnRespawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(LevelController.instance.respawnCount <= 0){
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
