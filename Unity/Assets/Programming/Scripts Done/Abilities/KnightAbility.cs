/* 7S_KNAB_001
 * Knight Ability Script
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class KnightAbility : MonoBehaviour {
	
	public	GameObject	player;	
	
	public float 		manaDrain;
	public int 			normalizeDmgMultiplier;
	public float		knightDamage;
	
	
	public	float		knightDrag = 0.75f;
	public	float		knightSpeed = 4.6f;
	public	int			knightJumps = 1;
	public	float		knightJumpBoost = 10f;
	
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
	
	public void SetKnightMovement() {
		player.GetComponent<Rigidbody>().drag = knightDrag;
		player.GetComponent<CharacterMovement>().playerStats.moveSpeed = knightSpeed; 
		player.GetComponent<CharacterMovement>().playerStats.maxJump = knightJumps;
		player.GetComponent<CharacterMovement>().playerStats.jumpReset = knightJumps;
		player.GetComponent<CharacterMovement>().playerStats.jumpBoost = knightJumpBoost;
		
	}
}
