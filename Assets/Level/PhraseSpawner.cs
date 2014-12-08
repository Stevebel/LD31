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
			totalLength = wordPlatforms[i].collider2D.bounds.size.x + (wordSpacing* wordsInPhrase.Length-1)/2;
		}

		float startWidth = center.x - totalLength;	

		for (int i = 0; i < wordsInPhrase.Length; i++) {
			float wordLength = wordPlatforms[i].collider2D.bounds.size.x;
			wordPlatforms[i].setPosition(new Vector2(startWidth,center.y));
			startWidth+= wordSpacing + wordLength;
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
