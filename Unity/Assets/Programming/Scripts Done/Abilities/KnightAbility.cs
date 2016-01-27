/* 7S_KNAB_001
 * Knight Ability Script
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class KnightAbility : MonoBehaviour {

	public GameObject	player;	
	public Animator 	anim;
	public GameObject 	defenceEffect;

	public float 		manaDrain;
	public int 			normalizeDmgMultiplier;
	public float		knightDamage;
	
	public	float		knightDrag = 0.75f;
	public	float		knightSpeed = 4f;
	public	int			knightJumps = 1;
	public	float		knightJumpBoost = 6f;

	void Start () {
		
	}

	void Update () {
		Shield();
		if(Input.GetButtonUp("Switch")){
			SetKnightMovement();
		}
	}
	
	void Shield () {
		if (Input.GetButtonDown("Skill")) {
			anim.SetBool("Block", true);
			Instantiate(defenceEffect, transform.position, Quaternion.identity);
			PlayerHpScript.shield = 0;
		}
		
		if (Input.GetButtonUp("Skill")) {
			PlayerHpScript.shield = normalizeDmgMultiplier;
			anim.SetBool("Block", false);
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
