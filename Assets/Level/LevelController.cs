using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//[ExecuteInEditMode]
public class LevelController : MonoBehaviour {
	public static LevelController instance;
	public Level level;
	public GameObject player;
	public Camera mainCamera;
	public PhraseSpawner phraseSpawner;
	private List<ObjectDefinition> definitions;
	private Vector2 checkpointPos;

	private int checkPointIndex = 0;
	private int currIndex = 0;

	public int respawnCount = 0;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		definitions = level.getDefinitions();
		if(definitions != null){
			definitions.Sort(delegate(ObjectDefinition a, ObjectDefinition b) {
				return a.height.CompareTo(b.height);
			});
		}
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
	void addVisibleDefinitions(){ addVisibleDefinitions(false); }
	void addVisibleDefinitions(bool addAll){
		if(!Application.isPlaying){
			definitions = level.createDefinitions();
		}
		float maxHeight = mainCamera.transform.position.y + 25f;
		if(addAll){
			currIndex = 0;
			maxHeight = float.MaxValue;
			ClearLevel();
		}
		if(currIndex >= definitions.Count){
			return;
		}
		
		ObjectDefinition definition = definitions[currIndex];
		while(definition.height < maxHeight){
			addDefinition(definition);

			currIndex++;
			if(currIndex >= definitions.Count){
				return;
			}
			definition = definitions[currIndex];
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
		if (definition is TextDefinition) {
						TextDefinition textDef = (TextDefinition)definition;
						WordPlatform[] words;
						if (textDef.spaced) {
								words = phraseSpawner.SpawnPhrase (textDef.text, new Vector2 (textDef.xPos, -textDef.height));
						} else {
								words = new WordPlatform[]{phraseSpawner.SpawnWord (textDef.text, new Vector2 (textDef.xPos, -textDef.height))};
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
		}else if(definition is PrefabDefinition){
			PrefabDefinition prefabDef = (PrefabDefinition)definition;
			GameObject obj = Instantiate(prefabDef.prefab) as GameObject;
			obj.transform.position.Set(prefabDef.xPos,-prefabDef.height, 0);
			obj.transform.parent = phraseSpawner.parent;
			if(!Application.isPlaying){
				obj.hideFlags = HideFlags.HideAndDontSave;
			}
		}else if (definition is CheckpointDefinition) {
			CheckpointDefinition checkDef = (CheckpointDefinition)definition;
			checkpointPos = new Vector2(checkDef.spawnXPos,  checkDef.spawnHeight);
			checkPointIndex = currIndex;
		}
	}

	public void Respawn()
	{
		respawnCount++;
		ClearLevel();
		currIndex = checkPointIndex;

		player.transform.position = checkpointPos;
		player.rigidbody2D.velocity = Vector2.zero;
		//player.transform.position = Checkpoint.current.transform.position;
		Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x, checkpointPos.y-10,Camera.main.transform.position.z);

		addVisibleDefinitions();
	}


}
