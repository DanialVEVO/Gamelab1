/* 7S_???_001
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
	public Vector3 floatStartPos;
	public bool moveUp;

	public Vector3 floatPos1;
	public Vector3 floatPos2;
	public float floatSpeed;

	public float floatY1;
	public float floatY2;

	void Start () {
		floatStartPos = transform.position;
	}

	void Update () {
		StandbyInScene();

	}
	
	void StandbyInScene () {

//		if (moveUp) {
//			if (transform.position.y <= floatStartPos.y + floatHeight){
//				transform.position += new Vector3 (0, 1, 0);
//			} else {
//				moveUp = false;
//			}
//		}  else {
//			if (transform.position.y == floatStartPos.y) {
//				moveUp = true;
//			} else {
//				transform.position += new Vector3 (0, -1, 0);
//			}
//		}

		//float floatSpeedTime = (Time.time) / floatSpeed ;
		transform.position = new Vector3(0, Mathf.Lerp(floatY1, floatY2, Time.time), 0);

		//transform.position = Vector3.Slerp(floatPos1, floatPos2, floatSpeedTime);


		//floating
		//rotating	
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
			PickupEffects();
		}
	}
	
}
