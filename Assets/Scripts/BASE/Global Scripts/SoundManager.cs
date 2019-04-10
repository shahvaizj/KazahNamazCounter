using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	public bool isMute = false;

	float checkpointTime = 0;

	[Header("Audio Sources")]
	public AudioSource audioo;
	public AudioSource bgAudioSource;

	[Header("BG Clips")]
	public AudioClip menuBG;
	public AudioClip[] GameBG;

	[Header("Sound Clips")]
	public AudioClip buttonClick;
	public AudioClip hit;
	public AudioClip getItem;

	public AudioClip [] levelCompleteStar;

	void Awake () {
		
		this.audioo = GetComponent<AudioSource> ();
		Debug.Log("GameAudiois = " + Toolbox.Instance.userPrefs.gameAudio );

		if (Toolbox.Instance.userPrefs.gameAudio == 1) { //handle audio in the beginning of the game
			UnMute ();
		
		} else {
		
			Mute ();		
		}
	}

	public void Mute(){

		isMute = true;

		AudioListener.volume = 0;
		Toolbox.Instance.userPrefs.gameAudio = 0;

		//Toolbox.Instance.userPrefs.Save ();

	}

	public void UnMute(){
	
		isMute = false;

		AudioListener.volume = 1;
		Toolbox.Instance.userPrefs.gameAudio = 1;

		//Toolbox.Instance.userPrefs.Save ();
	}

	public void Pause_All(){

		this.audioo.Pause ();
		this.bgAudioSource.Pause ();
	}

	public void UnPause_All(){

		this.audioo.UnPause ();
		this.bgAudioSource.UnPause ();

	}
		
	public void Stop_BGSound(){
	
		bgAudioSource.Stop ();
	}

	public void Play_MenuBGSound(int i){
	
		bgAudioSource.clip = GameBG[i];
		bgAudioSource.time = 2;
		this.bgAudioSource.Play ();

		this.bgAudioSource.loop = true;
	}

	public void Play_GameBGSound(){

//		Debug.Log ("Play 1!");

		//int i = Toolbox.Instance.userPrefs.currentLevel;

		//this.bgAudioSource.time = 0;

		//bgAudioSource.clip = GameBG[i];
		//this.bgAudioSource.Play ();

		//this.bgAudioSource.loop = false;

	}

	public void Play_SoundFromCheckpoint(){
	
////		Debug.Log ("Play 2!");
//		int i = Toolbox.Instance.userPrefs.currentLevel;

//		bgAudioSource.clip = GameBG[i];

//		this.bgAudioSource.time = checkpointTime;
//		this.bgAudioSource.Play ();

	}

	//Other Sound Effects

	public void PlaySound(AudioClip _clip){
		audioo.PlayOneShot (_clip);
	}

	public void Play_ButtonClick(){

		this.audioo.clip = buttonClick;
		this.audioo.Play ();
	}

	public void Set_CheckpointTime(){
	
		checkpointTime = this.bgAudioSource.time;
	}
}
