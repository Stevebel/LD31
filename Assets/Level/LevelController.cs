using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {
	public static LevelController instance;
	public Level level;
	public GameObject player;
	public Camera mainCamera;
	public PhraseSpawner phraseSpawner;
	private List<ObjectDefinition> definitions;
	private Vector2 checkpointPos;

	// Use this for initialization
	void Start () {
		instance = this;
		definitions = level.getDefinitions();
		definitions.Sort(delegate(ObjectDefinition a, ObjectDefinition b) {
			return a.height.CompareTo(b.height);
		});
	}
	
	// Update is called once per frame
	void Update () {
		addVisibleDefinitions();
	}

	void addVisibleDefinitions(){
		if(definitions.Count <= 0){
			return;
		}
		float maxHeight = -mainCamera.transform.position.y + mainCamera.orthographicSize + 5f;
		Debug.Log(mainCamera.transform.position.y);
		
		ObjectDefinition definition = definitions[0];
		while(definition.height < maxHeight){
			addDefinition(definition);
			definitions.RemoveAt(0);

			if(definitions.Count <= 0){
				return;
			}
			definition = definitions[0];
		}
	}

	void addDefinition(ObjectDefinition definition){
		if (definition is TextDefinition) {
						TextDefinition textDef = (TextDefinition)definition;
						WordPlatform[] words;
						if (textDef.spaced) {
								words = phraseSpawner.SpawnPhrase (textDef.text, new Vector2 (textDef.xPos, -textDef.height));
						} else {
								words = new WordPlatform[]{phraseSpawner.SpawnWord (textDef.text, new Vector2 (textDef.xPos, -textDef.height))};
						}

						foreach (WordPlatform word in words) {
								word.setTint (textDef.color);
								word.setBrightness (textDef.brightness);
								word.setTextSize (textDef.size);
								word.hideFlags = HideFlags.HideAndDontSave;
								foreach (System.Type script in textDef.scripts) {
										word.gameObject.AddComponent (script);
								}
						}
				} else if (definition is AudioDefinition) {
						Camera.main.audio.clip = ((AudioDefinition)definition).clip;
						Camera.main.audio.Play ();
				} else if (definition is CheckpointDefinition) {
					checkpointPos = new Vector2(((CheckpointDefinition)definition).xPos,  definition.height);
				}
	}

	public void Respawn(){
			player.transform.position = checkpointPos;
			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x, checkpointPos.y-10,Camera.main.transform.position.z);
		}


}
