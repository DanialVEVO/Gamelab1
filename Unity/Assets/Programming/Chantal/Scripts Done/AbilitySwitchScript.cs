/* 7S_TF_001
 * Ability Switch Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilitySwitchScript : MonoBehaviour {
	
	public int abilityNum;
	public GameObject[] AbilityImgsObjArr;  //size 3
	public Sprite[] abilityImgSprArr;		//size 5
	public GameObject[] abilities;			//size 5
	public bool[] abilityUnlocked;			//size 5
	public bool inNormalMode;
	public ManaScript manaScr;
	public float minManaNeed;
	
	void Start () {
		abilityUnlocked[0] = true;
		SetSwitchedAbility();
	}
	
	void Update() {
		SetAbilityImg();
		SwitchAbility();
	}
	
	public void SwitchAbility () {
		if (abilityUnlocked[abilityNum] == true) {
			if (Input.GetButtonDown("Switch")){
				if (abilityNum == 0) {
					SetSwitchedAbility();
				} else if (minManaNeed <= manaScr.manaValue) {
					SetSwitchedAbility();
				}
			}
		} 	
	}
	
	public void SetSwitchedAbility () {
		for (int i = 0; i < abilities.Length; i++){
			abilities[i].SetActive(false);
		}
		abilities[abilityNum].SetActive(true);
		CheckMode();
	}
	
	void CheckMode () {
		if (abilities[0].activeInHierarchy){
			inNormalMode = true;
		} else {
			inNormalMode = false;
		}
	}
	
	public void GetAbilityImg () {
		for (int i = 0; i < AbilityImgsObjArr.Length; i++) {
			AbilityImgsObjArr[i].GetComponent<AbilityImgArr>().ShowImg();
		}
	}
	
	void NumberCheck () {
		if (abilityNum > abilityImgSprArr.Length - 1) {
			abilityNum = 0;
		} else if (abilityNum < 0) {
			abilityNum = abilityImgSprArr.Length - 1;
		}
		GetAbilityImg();
	}
	
	public void SetAbilityImg () {
		if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
			abilityNum++;
			NumberCheck();
		} else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
			abilityNum--;
			NumberCheck();
		}
	}
	
}
