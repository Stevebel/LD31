using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {
	public GameObject player;
	public Camera mainCamera;
	private List<ObjectDefinition> definitions;
	// Use this for initialization
	void Start () {
		definitions = new Level().getDefinitions();
		definitions.Sort(delegate(ObjectDefinition a, ObjectDefinition b) {
			return a.height.CompareTo(b.height);
		});
	}
	
	// Update is called once per frame
	void Update () {
		float maxHeight = mainCamera.transform.position.x + mainCamera.orthographicSize + 5f;

		ObjectDefinition definition = definitions[0];
		while(definition.height < maxHeight){
			addDefinition(definition);
			definitions.RemoveAt(0);
			definition = definitions[0];
		}
	}

	void Respawn(){
		//TODO
		}

	void addDefinition(ObjectDefinition definition){
		//TODO
	}
}
