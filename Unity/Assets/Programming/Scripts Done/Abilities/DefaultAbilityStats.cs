/* <no code>
 * Default Ability Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class DefaultAbilityStats : MonoBehaviour {

	public	GameObject	player;	

	public	float		defaultDrag;
	public	float		defaultSpeed;
	public	int			defaultJumps;
	public	float		defaultJumpBoost;

	void Start () {
		defaultDrag = player.GetComponent<Rigidbody>().drag;
		defaultSpeed = player.GetComponent<CharacterMovement>().playerStats.moveSpeed;
		defaultJumps = player.GetComponent<CharacterMovement>().playerStats.maxJump;
		defaultJumpBoost = player.GetComponent<CharacterMovement>().playerStats.jumpBoost;
	}

	void Update () {
		if(Input.GetButtonUp("Switch")){
			SetDefaultStats();
		}
	}

	public void SetDefaultStats () {
		player.GetComponent<Rigidbody>().drag = defaultDrag;
		player.GetComponent<CharacterMovement>().playerStats.moveSpeed = defaultSpeed; 
		player.GetComponent<CharacterMovement>().playerStats.maxJump = defaultJumps;
		player.GetComponent<CharacterMovement>().playerStats.jumpReset = defaultJumps;
		player.GetComponent<CharacterMovement>().playerStats.jumpBoost = defaultJumpBoost;
	}
}
