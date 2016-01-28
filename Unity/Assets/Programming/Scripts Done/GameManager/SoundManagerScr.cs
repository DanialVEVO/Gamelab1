/*
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class SoundManagerScr : MonoBehaviour {

	//public AudioSource audioSource;
	public AudioClip[] bgm;
	/* 0 = menu
	 * 1 = lvl1
	 * 2 = lvl2
	 * 3 = lvl3
	 * 4 = dead
	 */

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	void OnLevelWasLoaded(int levelID) {
		for (int i = 0; i < bgm.Length; i++){
			if (levelID == i){
				GetComponent<AudioSource>().clip = bgm[i];
				GetComponent<AudioSource>().Play();
			}
		}
	}

	public void Dead() {
		GetComponent<AudioSource>().clip = bgm[4];
		GetComponent<AudioSource>().Play();
	}
}
