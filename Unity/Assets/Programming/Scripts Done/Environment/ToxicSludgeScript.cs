/* 7S_ToxicS_001
 * Toxic Sludge Script 
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class ToxicSludgeScript : MonoBehaviour {

	public PlayerHpScript playerHpScr;
	public PlayerStats playerStats;
	public CharacterMovement characterMovementScr;
	public int toxicDmg = 1;
	public float toxicDmgTimer = 1;
	public float moveSpeedDecrease = 2;

	private PlayerStats defaulyPlayerStats;
	private float toxicDmgTimerRes;
	private float toxicMoveSpeed;
	private float normalMoveSpeed;
	private bool inToxic;

	void Start() {
		defaulyPlayerStats = new PlayerStats();
		toxicDmgTimerRes = toxicDmgTimer;
		normalMoveSpeed = defaulyPlayerStats.moveSpeed;
		toxicMoveSpeed = defaulyPlayerStats.moveSpeed / moveSpeedDecrease;
	}

	public void ToxicSpeed() {
		characterMovementScr.playerStats.moveSpeed = toxicMoveSpeed;
	}

	public void GetToxicDmg() {
		toxicDmgTimer -= Time.deltaTime;
		if (toxicDmgTimer <= 0) {
			playerHpScr.GetDmg(toxicDmg);
			toxicDmgTimer = toxicDmgTimerRes;
		}
	}

	void Update(){
		if (inToxic){
			GetToxicDmg();
		}
	}

	public void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Player") {
			inToxic = true;
			ToxicSpeed();
		}
	}

	public void OnCollisionExit() {
		inToxic = false;
		toxicDmgTimer = toxicDmgTimerRes;
		characterMovementScr.playerStats.moveSpeed = normalMoveSpeed;
	}
}