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
	
	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetAstroMovement() {
		player.GetComponent<Rigidbody>().drag = astroDrag;
		player.GetComponent<CharacterMovement>().playerStats.moveSpeed = astroSpeed; 
		player.GetComponent<CharacterMovement>().playerStats.maxJump = astroJumps;
		player.GetComponent<CharacterMovement>().playerStats.jumpReset = astroJumps;
		player.GetComponent<CharacterMovement>().playerStats.jumpBoost = astroJumpBoost;
		
	}
}
