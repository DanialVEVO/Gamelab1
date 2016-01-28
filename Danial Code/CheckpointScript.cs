/* 7S_SPAW_001
 * Player Spawn Script
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class CheckpointScript : ForInEditor {

	public Transform checkpointLocation;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == ("Player")){
			other.transform.GetComponent<PlayerManager>().checkpoint = checkpointLocation;
		}
	}
}
