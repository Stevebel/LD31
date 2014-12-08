using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[ExecuteInEditMode]
public class LevelController : MonoBehaviour {
	public Level level;
	public GameObject player;
	public Camera mainCamera;
	public PhraseSpawner phraseSpawner;
	private List<ObjectDefinition> definitions;

	// Use this for initialization
	void Start () {
		definitions = level.getDefinitions();
		definitions.Sort(delegate(ObjectDefinition a, ObjectDefinition b) {
			return a.height.CompareTo(b.height);
		});
		phraseSpawner.parent.hideFlags = HideFlags.None;
	}
	
	// Update is called once per frame
	void Update () {
		if(!Application.isPlaying){
			addVisibleDefinitions(true);
		}else{
			addVisibleDefinitions(false);
		}

	}

	void addVisibleDefinitions(bool addAll){
		if(definitions == null){
			definitions = level.createDefinitions();
		}
		if(definitions.Count <= 0){
			return;
		}
		float maxHeight = -mainCamera.transform.position.y + 25f;
		if(addAll){
			maxHeight = float.MaxValue;
			ClearLevel();
		}
		
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
	void ClearLevel(){
		List<GameObject> children = new List<GameObject>();
		foreach(Transform child in phraseSpawner.parent){
			children.Add(child.gameObject);
		}
		children.ForEach(delegate(GameObject obj) { DestroyImmediate(obj); });
	}

	void addDefinition(ObjectDefinition definition){
		if(definition is TextDefinition){
			TextDefinition textDef = (TextDefinition) definition;
			WordPlatform[] words;
			if(textDef.spaced){
				words = phraseSpawner.SpawnPhrase(textDef.text, new Vector2(textDef.xPos,-textDef.height));
			}else{
				words = new WordPlatform[]{phraseSpawner.SpawnWord(textDef.text, new Vector2(textDef.xPos,-textDef.height))};
			}

			foreach(WordPlatform word in words){
				word.setTint(textDef.color);
				word.setBrightness(textDef.brightness);
				word.setTextSize(textDef.size);
				if(!Application.isPlaying){
					word.gameObject.hideFlags = HideFlags.HideAndDontSave;
				}
				foreach(System.Type script in textDef.scripts){
					word.gameObject.AddComponent(script);
				}
			}
		}else if(definition is AudioDefinition){
			if(Application.isPlaying){
				Camera.main.audio.clip = ((AudioDefinition)definition).clip;
				Camera.main.audio.Play ();
			}
		}
	}

	void Respawn(){
		//TODO
		}


}
