/* 7S_ToxicS_001
 * Toxic Sludge Script 
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class ToxicSludgeScript : MonoBehaviour {

	public PlayerHpScript playerHpScr;
	//public Movement movementScr;
	public int toxicDmg;
	public float toxicDmgTimer;
	float toxicDmgTimerRes;
	float toxicMoveSpeed;
	float normalMoveSpeed;

	void Start() {
		toxicDmgTimerRes = toxicDmgTimer;
	//	normalMoveSpeed = movementScr.moveSpeed;
	//	toxicMoveSpeed = movementScr.moveSpeed / 2;
	}

	public void ToxicSpeed() {
	//	movementScr.moveSpeed = toxicMoveSpeed;
	}

	public void GetToxicDmg() {
		toxicDmgTimer -= Time.deltaTime;
		if (toxicDmgTimer <= 0) {
			playerHpScr.GetDmg(toxicDmg);
			toxicDmgTimer = toxicDmgTimerRes;
		}
	}

	public void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Player") {
			ToxicSpeed();
			GetToxicDmg();
		}
	}

	public void OnTriggerExit() {
		toxicDmgTimer = toxicDmgTimerRes;
		//movementScr.moveSpeed = normalMoveSpeed;
	}
}
