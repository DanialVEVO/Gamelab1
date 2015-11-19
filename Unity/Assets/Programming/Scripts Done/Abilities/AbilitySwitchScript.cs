/* 7S_TF_001
 * Ability Switch Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilitySwitchScript : MonoBehaviour {
	
	public int abilityNum;
	public Sprite lockedAbilitySpr;
	public Sprite[] unlockedAbilitySprArr = new Sprite[5];
	public GameObject[] AbilityImgsObjArr = new GameObject[3];
	public GameObject[] abilities = new GameObject[5];
	public bool[] abilityUnlocked = new bool[5];
	public bool inNormalMode;
	public ManaScript manaScr;
	public float minManaNeed;
	public Sprite[] abilityImgSprArr = new Sprite[5];
	
	void Start () {
		abilityUnlocked[0] = true;
		SetSwitchedAbility();
		SetAbilitieSpr();
	}
	
	void Update() {
		SetAbilityImg();
		SwitchAbility();
	}

	public void SetAbilitieSpr(){
		for (int i = 0; i < abilityUnlocked.Length; i++){
			if (abilityUnlocked[i] == false) {
				abilityImgSprArr[i] = lockedAbilitySpr;
			} else {
				abilityImgSprArr[i] = unlockedAbilitySprArr[i];
			}
		}
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
