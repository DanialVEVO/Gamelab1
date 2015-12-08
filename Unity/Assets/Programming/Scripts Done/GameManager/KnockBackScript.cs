/* 7S_DMG_001
 * DMG Script for Melee Weapons
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class KnockBackScript : MonoBehaviour {

	public float force = 100;
	public float stopMoveTime = 0.5f;

	public void KnockBack (Collision other) {
		if (transform.tag != other.transform.tag){
			if (other.transform.tag == "Enemy" || other.transform.tag == "Player"){
				Vector3 dir = other.transform.position - transform.position; 
				dir.y = 0;
				other.rigidbody.AddForce(dir.normalized * force, ForceMode.Acceleration);
				StartCoroutine(WaitTillStop(other));
			}
		}
	}
	
	IEnumerator WaitTillStop (Collision other){
		yield return new WaitForSeconds(stopMoveTime);
		other.rigidbody.Sleep();
	}
}

