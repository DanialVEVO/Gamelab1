/* 7S_KNAB_001
 * Knight Ability Script
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class KnightAbility : MonoBehaviour {

	public int normalizeDmgMultiplier;

	// Use this for initialization
	void Start () {

	}
			
	// Update is called once per frame
	void Update () {
		Shield();	
	}

	void Shield () {
		if (Input.GetButtonDown("Function")) {
			print("defending");
			PlayerHpScript.shield = 0;
		}

		if (Input.GetButtonUp("Function")) {
			print("not defending");
			PlayerHpScript.shield = normalizeDmgMultiplier;
		}
	}
}
