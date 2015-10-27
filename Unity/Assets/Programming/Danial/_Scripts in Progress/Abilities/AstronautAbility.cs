/* 7S_ASAB_001
 * Astronaut Ability Script
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class AstronautAbility : MonoBehaviour {

	public	CharacterController characterController;
	public	GameObject	player;	
//	public	Rigidbody 	rbPlayer;
	public	float		astroDrag = 1.25f;
	public	float		astroSpeed = 4.8f;
	public	float		astroJumpBoost = 10f;
	public	int			astroJumps = 2;

	// Use this for initialization
	public void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetAstroMovement() {
//		rbPlayer.drag = astroDrag;
		player.GetComponent<Rigidbody>().drag = astroDrag;
		player.GetComponent<CharacterMovement>().playerStats.moveSpeed = astroSpeed; 
		player.GetComponent<CharacterMovement>().playerStats.maxJump = astroJumps;
		player.GetComponent<CharacterMovement>().playerStats.jumpReset = astroJumps;
		player.GetComponent<CharacterMovement>().playerStats.jumpBoost = astroJumpBoost;
	
	}
}
