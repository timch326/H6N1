using UnityEngine;
using System.Collections;

public class GamePlayMusic : MonoBehaviour {

	public GameObject currentMusic;
	public AudioClip levelMusic;

	// Use this for initialization
	void Awake () {
		currentMusic = GameObject.Find ("GameMusicSingleton");
		currentMusic.audio.clip = levelMusic; 
		currentMusic.audio.Play();
	}
}
