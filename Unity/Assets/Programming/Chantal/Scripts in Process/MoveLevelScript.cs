/* 7S_NXTL_001
 * Changing Level Scene Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class MoveLevelScript : MonoBehaviour {

	public int levelId;

	void OnCollisionEnter (Collision coll) {
		if (coll.gameObject.tag == "Player"){
			Application.LoadLevel(levelId);
		}
	}
}
