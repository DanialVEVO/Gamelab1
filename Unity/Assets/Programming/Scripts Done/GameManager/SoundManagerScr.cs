/*
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class SoundManagerScr : MonoBehaviour {

	public AudioClip[] bgm;
	/* 0 = menu
	 * 1 = lvl1
	 * 2 = lvl2
	 * 3 = lvl3
	 * 4 = dead
	 */

	void Awake () {
		DontDestroyOnLoad(gameObject);
		GetComponent<AudioSource>().PlayOneShot(bgm[0]);
	}

	void OnLevelWasLoaded(int levelID) {
		for (int i = 0; i < bgm.Length; i++){
			if (levelID == i){
				GetComponent<AudioSource>().PlayOneShot(bgm[i]);
			}
		}
	}

	public void Dead() {
		GetComponent<AudioSource>().PlayOneShot(bgm[4]);
	}
}
