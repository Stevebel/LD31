using UnityEngine;
using System.Collections;

public class PhraseSpawner : MonoBehaviour {

	public WordPlatform wordSeed;
	public float wordSpacing;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnPhrase(string phrase, Vector2 position){
		string[] wordsInPhrase = phrase.Split();
		WordPlatform[] wordPlatforms = new WordPlatform[wordsInPhrase.Length];
		float totalLength = 0;
		for (int i = 0; i < wordsInPhrase.Length; i++) {
			wordPlatforms[i] = SpawnWord(wordsInPhrase[i]);
			totalLength = wordPlatforms[i].collider2D.bounds.size.x + (wordSpacing* wordsInPhrase.Length-1)/2;
		}

		float startWidth = position.x - totalLength;	

		for (int i = 0; i < wordsInPhrase.Length; i++) {
			float wordLength = wordPlatforms[i].collider2D.bounds.size.x;
			wordPlatforms[i].setPosition(startWidth,position.y);
			startWidth+= wordSpacing + wordLength;
		}

	}

	WordPlatform SpawnWord(string word){
		word = word.ToUpper ();
		WordPlatform wordToAdd = (WordPlatform)Instantiate (wordSeed);
		wordToAdd.InitializeText (word);
		//wordToAdd.SendMessage ("InitializeText", word);
		return wordToAdd;
	}
}
