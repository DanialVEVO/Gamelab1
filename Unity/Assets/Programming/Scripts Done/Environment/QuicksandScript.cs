/* 7S_Quicksand_001
 * Quicksand Script 
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class QuicksandScript : MonoBehaviour {

	public PlayerHpScript playerHpScr;
	public Rigidbody playerRigidbody;
	public int sinkDmg = 1;
	public int sinkSlow = 25;
	public float sinkDmgTimer = 1;

	private float defaultDrag;
	private float sinkDmgTimerRes;
	
	void Start() {
		sinkDmgTimerRes = sinkDmgTimer;
		defaultDrag = playerRigidbody.drag;
	}

	public void Sink() {
		playerRigidbody.drag = sinkSlow;

		sinkDmgTimer -= Time.deltaTime;
		if (sinkDmgTimer <= 0) {
			playerHpScr.GetDmg(sinkDmg);
			sinkDmgTimer = sinkDmgTimerRes;
		}
	}

	public void StopSink() {
		playerRigidbody.drag = defaultDrag;
	}
	
	public void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Player") {
			Sink();
		}
	}

	public void OnTriggerExit() {
		StopSink();
		sinkDmgTimer = sinkDmgTimerRes;
	}

}
