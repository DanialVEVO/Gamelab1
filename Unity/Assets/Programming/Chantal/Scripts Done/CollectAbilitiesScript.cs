/* 7S_PUA_001
 * Pickup Abilities Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class CollectAbilitiesScript : MonoBehaviour {

	public int abilityId;
	//public GameObject pickupEffect;
	public AbilitySwitchScript abilitySwitchScr;
	public Sprite unlockedAbilityIcon;

	public float floatHeight;
	private Vector3 floatStartPos;
	public bool floatUp;
	public float floatSpeed;
	public float rotationSpeed;

	public AbilityGuideScript abilityGuideScr;
	
	void Start () {
		floatStartPos = transform.position;
	}

	void Update () {
		StandbyInScene();
	}

	void StandbyInScene () {
		if (transform.position.y >= floatStartPos.y + floatHeight) {
			floatUp = false;
		}
		if (transform.position.y <= floatStartPos.y) {
			floatUp = true;
		}

		if (floatUp) {
			transform.position += new Vector3 (0, 1 * floatSpeed * Time.deltaTime, 0);
		} else {
			transform.position += new Vector3 (0, -1 * floatSpeed * Time.deltaTime, 0);
		}
	
		transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);	
	}
	
	void UnlockAbility () {
		abilitySwitchScr.abilityImgSprArr[abilityId] = unlockedAbilityIcon;
		abilitySwitchScr.abilityUnlocked[abilityId] = true;
		abilitySwitchScr.GetAbilityImg();
	}
	
	void PickupEffects () {
		//Instantiate(pickupEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player"){
			UnlockAbility();
			abilityGuideScr.OpenAbilityGuide(abilityId);
			PickupEffects();
		}
	}
	
}
