/* 7S_PUA_001
 * Pickup Abilities Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class CollectAbilitiesScript : FloatingObjectsScript {

	public int abilityId;
	public AbilitySwitchScript abilitySwitchScr;
	public AbilityGuideScript abilityGuideScr;
	//public SpawnEnemiesScript spawnEnemiesScr;
	//public GameObject pickupEffect;

	void Start (){
		abilitySwitchScr = GameObject.Find("AbilitySwitch").GetComponent<AbilitySwitchScript>();
		abilityGuideScr = GameObject.Find("AbilityGuides").GetComponent<AbilityGuideScript>();
	}

	void Update () {
		FloatingObject();
	}

	void UnlockAbility () {
		abilitySwitchScr.abilityUnlocked[abilityId] = true;
		abilitySwitchScr.SetAbilitieSpr();
		abilitySwitchScr.GetAbilityImg();
	}
	
	void PickupEffects () {
		//Instantiate(pickupEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player"){
			UnlockAbility();
			//spawnEnemiesScr.SpawnEnemies();
			abilityGuideScr.OpenAbilityGuide(abilityId);
			PickupEffects();
		}
	}
}
