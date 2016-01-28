/* <no code>
 * Default Ability Script
 * Scripted by Chantal & Danial
 */

using UnityEngine;
using System.Collections;

public class DefaultAbilityStats : MonoBehaviour {

	public	GameObject	player;	

	void Update () {
		if(Input.GetButtonUp("Switch")){
			SetDefaultStats();
		}
	}

	public void SetDefaultStats () {
		player.GetComponent<CharacterMovement>().MovementReset();
	}
}
