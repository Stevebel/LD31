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
		Add (new CheckpointDefinition(0,17,0));
		Add (new AudioDefinition(5, audioClips.getAudioClip(AudioClips.CLIP.INSTRUCTIONS_MUSIC)));
		Add (new CheckpointDefinition(88,118,1));
		Add (new AudioDefinition(100, audioClips.getAudioClip(AudioClips.CLIP.FAKE_GAME_MUSIC)));
		Add (new CheckpointDefinition(169,151,0));

		Add (new AudioDefinition(170, audioClips.getAudioClip(AudioClips.CLIP.CREDITS_GAME_MUSIC)));
		/*
		Add(new TextDefinition(10, "Adjust screen brightness").XPos(-23).Spaced(false).Brightness(1).Script(typeof(FadeOnCollision)));
		Add(new TextDefinition(14, "until Viking is clearly visible").XPos(-25).Spaced(false).Brightness(1).Script(typeof(FadeOnCollision)));

		float yPos = 24;
		Add (new CheckpointDefinition(yPos,yPos,0));
		Add (new TextDefinition(yPos+=1, "Don't Fall off the Screen").XPos(-22.5f).Spaced(false).Script(typeof(ActivateOnRespawn)).Script(typeof(FadeOnCollision)));
		Add (new AudioDefinition(yPos+=5, audioClips.getAudioClip(AudioClips.CLIP.INSTRUCTIONS_MUSIC)));
		Add(new TextDefinition(yPos+=5, "Press D or Right to Move Right").XPos(-36.5f).Size(1.2f).Spaced(false));
		Add(new TextDefinition(yPos+=20, "Press S or Left to Move Left").XPos(-16.5f).Size(1.2f).Spaced(false));
		Add(new TextDefinition(yPos+=25, "Press Space      to Jump").XPos(-36.5f).Size(1.2f));
		float xPos = 25;
		Add(new TextDefinition(yPos+=25, "Are").XPos(xPos).Size(2f));
		Add(new TextDefinition(yPos+=10, "You").XPos(xPos-=15).Size(2f));
		Add(new TextDefinition(yPos+=10, "Ready").XPos(xPos-=25).Size(2f));
		Add(new TextDefinition(yPos+=12, "To").XPos(xPos-=18).Size(2.5f).Script(typeof(FadeOnCollisionLong)));

		Add (new CheckpointDefinition(yPos,yPos+=50,-30));
		Add (new AudioDefinition(yPos+=0.1f, audioClips.getAudioClip(AudioClips.CLIP.FAKE_GAME_MUSIC)));
		Add(new TextDefinition(yPos+=10, "Save the World").XPos(xPos=-36).Size(3f).Spaced(false).Script(typeof(FadeOnSwitch)));

		Add (new CheckpointDefinition(219f, 219f, 0f));
		*/
		return definitions;
	}
	private void Add(ObjectDefinition o){
		definitions.Add(o);
	}
}
