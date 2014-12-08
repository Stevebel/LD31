using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {
	private List<ObjectDefinition> definitions;
	public AudioClips audioClips;

	public Level(){}

	void Awake(){
		definitions = createDefinitions();
	}

	public List<ObjectDefinition> getDefinitions(){
		return definitions;
	}
	public List<ObjectDefinition> createDefinitions(){
		definitions = new List<ObjectDefinition>();
		Add(new TextDefinition(10, "Adjust screen brightness").XPos(-23).Spaced(false).Brightness(1).Script(typeof(FadeOnCollision)));
		Add(new TextDefinition(14, "until Viking is clearly visible").XPos(-25).Spaced(false).Brightness(1).Script(typeof(FadeOnCollision)));


		Add (new AudioDefinition(30, audioClips.getAudioClip(AudioClips.CLIP.INSTRUCTIONS_MUSIC)));
		Add(new TextDefinition(30, "Press D or Right to Move Right").XPos(-36.5f).Size(1.2f).Spaced(false));
		Add(new TextDefinition(50, "Press S or Left to Move Left").XPos(-16.5f).Size(1.2f).Spaced(false));
		Add(new TextDefinition(75, "Press Space      to Jump").XPos(-36.5f).Size(1.2f));

		Add (new AudioDefinition(90, audioClips.getAudioClip(AudioClips.CLIP.FAKE_GAME_MUSIC)));
		return definitions;
	}
	private void Add(ObjectDefinition o){
		definitions.Add(o);
	}
}
