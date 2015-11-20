/* 7S_Quicksand_001
 * Quicksand Script 
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class QuicksandDmgScript : MonoBehaviour {

	public QuicksandScript QuicksandScr;

	public void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Player") {
			QuicksandScr.sinkPanic = true;
		}
	}

	public void OnTriggerExit() {
		QuicksandScr.sinkPanic = false;
	}

}
