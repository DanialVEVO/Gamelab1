/* 7S_ASAB_001
 * Astronaut Ability Script
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class AstronautAbility : MonoBehaviour {
	
	public	GameObject	player;	
	public	float 		manaDrain;
	
	public	float		astroDrag = 1.25f;
	public	float		astroSpeed = 4.8f;
	public	int			astroJumps = 2;
	public	float		astroJumpBoost = 12f;
	public 	GameObject	jumpEffect;
	private	Vector3		particlePos;
	public  float 		particleSpawnHeight = 2.5f;

	public void Start () {

	}

	void Update () {
		if(Input.GetButtonUp("Switch")){
			SetAstroMovement();
		}	
		if(Input.GetButtonDown("Jump")){
			particlePos = transform.position;
			particlePos.y += particleSpawnHeight;
			Instantiate(jumpEffect, particlePos, Quaternion.identity);
		}
	}
	
	public void SetAstroMovement() {
		player.GetComponent<Rigidbody>().drag = astroDrag;
		player.GetComponent<CharacterMovement>().playerStats.moveSpeed = astroSpeed; 
		player.GetComponent<CharacterMovement>().playerStats.maxJump = astroJumps;
		player.GetComponent<CharacterMovement>().playerStats.jumpReset = astroJumps;
		player.GetComponent<CharacterMovement>().playerStats.jumpBoost = astroJumpBoost;
		
	}
}
