using UnityEngine;
using System.Collections;

public class PhraseSpawner : MonoBehaviour {

	public WordPlatform wordSeed;
	public Transform parent;
	public float wordSpacing;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public WordPlatform[] SpawnPhrase(string phrase, Vector2 center){
		string[] wordsInPhrase = phrase.Split();
		WordPlatform[] wordPlatforms = new WordPlatform[wordsInPhrase.Length];
		float totalLength = 0;
		for (int i = 0; i < wordsInPhrase.Length; i++) {
			wordPlatforms[i] = SpawnWord(wordsInPhrase[i]);
		}

		float xPos = center.x ;	

		for (int i = 0; i < wordsInPhrase.Length; i++) {
			WordPlatform word = wordPlatforms[i];
			word.setPosition(new Vector2(xPos,center.y));
			xPos =  word.collider2D.bounds.center.x + word.collider2D.bounds.extents.x + wordSpacing;
		}

		return wordPlatforms;
	}
	public WordPlatform SpawnWord(string word){
		return SpawnWord(word, Vector2.zero);
	}
	public WordPlatform SpawnWord(string word, Vector2 position){
		word = word.ToUpper ();
		WordPlatform wordToAdd = (WordPlatform)Instantiate (wordSeed);
		wordToAdd.name = word;
		wordToAdd.InitializeText (word);
		wordToAdd.setPosition (position);
		if(parent){
			wordToAdd.transform.parent = parent;
		}
		//wordToAdd.SendMessage ("InitializeText", word);
		return wordToAdd;
	}
}
