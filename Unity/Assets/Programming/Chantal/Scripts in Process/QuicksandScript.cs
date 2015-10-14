/* 7S_Quicksand_001
 * Quicksand Script 
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class QuicksandScript : MonoBehaviour {

	public PlayerHpScript playerHpScr;
	public Rigidbody playerRigidbody;
	public int sinkDmg;
	public int sinkSlow;
	public int defaultDrag;
	public bool sinkPanic;
	public float sinkDmgTimer;
	float sinkDmgTimerRes;


	void Start() {
		sinkDmgTimerRes = sinkDmgTimer;
	}

	public void Sink() {
		playerRigidbody.useGravity = true;
		playerRigidbody.drag = sinkSlow;
	}

	public void StopSink() {
		playerRigidbody.useGravity = false;
		playerRigidbody.drag = defaultDrag;
	}

	public void GetSinkDmg() {
		if (sinkPanic) {
			sinkDmgTimer -= Time.deltaTime;
			if (sinkDmgTimer <= 0) {
				playerHpScr.GetDmg(sinkDmg);
				sinkDmgTimer = sinkDmgTimerRes;
			}
		}
	}

	public void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Player") {
			Sink();
			GetSinkDmg();
		}
	}

	public void OnTriggerExit() {
		StopSink();
		sinkDmgTimer = sinkDmgTimerRes;
	}

}
