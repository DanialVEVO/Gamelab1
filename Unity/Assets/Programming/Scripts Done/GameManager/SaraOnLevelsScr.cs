/* 
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class SaraOnLevelsScr : MonoBehaviour {

	public Vector3[] lvlStartPos;
	public int maxLevels;

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	void OnLevelWasLoaded(int levelID) {
		for (int i = 1; i < maxLevels; i++){
			if (levelID == i){
				transform.position = lvlStartPos[i];
			}
		}
	}
}
