/* 7S_NXTL_001
 * Changing Level Scene Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class MoveLevelScript : MonoBehaviour {

	public int nextLevelId;

	void OnCollisionEnter (Collision coll) {
		if (coll.gameObject.tag == "Player"){
			Application.LoadLevel(nextLevelId);
		}
	}
}
