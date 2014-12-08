using UnityEngine;
using System.Collections;

public class AudioClips : MonoBehaviour {
	public enum CLIP{
		INSTRUCTIONS_MUSIC = 0,
		FAKE_GAME_MUSIC,
		CREDITS_GAME_MUSIC
	};
	public AudioClip[] clips;

	public AudioClip getAudioClip(CLIP clip){
		return clips[(int)clip];
	}
}
