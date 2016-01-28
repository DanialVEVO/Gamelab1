/* 7S_TF_001
 * Ability Switch Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilitySwitchScript : MonoBehaviour {
	
	public int abilityNum;
	private int curAbilityNum;
	public Sprite lockedAbilitySpr;
	public Sprite[] unlockedAbilitySprArr = new Sprite[5];
	public GameObject[] AbilityImgsObjArr = new GameObject[3];
	public GameObject[] abilities = new GameObject[5];
	public Transform player;
	public bool[] abilityUnlocked = new bool[5];
	public bool inNormalMode;
	public ManaScript manaScr;
	public float minManaNeed;
	public GameObject switchEffect;
	public Sprite[] abilityImgSprArr = new Sprite[5];
	private bool showSwitchEffect = false;

//	void OnLevelWasLoaded(int levelID) {
	void Start() {
//		if (levelID >= 1){
			FindAbilityObjects();
			abilityUnlocked[0] = true;
			SetSwitchedAbility(0);
			SetAbilitieSpr();
			GetAbilityImg();
			player = GameObject.FindWithTag("Player").transform;
			showSwitchEffect = true;
//		}
	}
	
	void Update() {
		SetAbilityImg();
		SwitchAbility();
	}

	void FindAbilityObjects(){
		Transform playerAbilities = GameObject.Find("PlayerAbilities").transform;
		abilities[0] = playerAbilities.Find("Default").gameObject;
		abilities[1] = playerAbilities.Find("Knight").gameObject;
		abilities[2] = playerAbilities.Find("Hero").gameObject;
		abilities[3] = playerAbilities.Find("Cowboy").gameObject;
		abilities[4] = playerAbilities.Find("Astronaunt").gameObject;
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
					SetSwitchedAbility(abilityNum);
				} else if (abilityNum == curAbilityNum) {
					SetSwitchedAbility(0);
				} else if (minManaNeed <= manaScr.manaValue) {
					SetSwitchedAbility(abilityNum);
				}
			}
		} 	
	}
	
	public void SetSwitchedAbility (int setNum) {
		if(showSwitchEffect){
			Instantiate(switchEffect, player.position, Quaternion.identity);
		}

		for (int i = 0; i < abilities.Length; i++){
			abilities[i].SetActive(false);
		}
		abilities[setNum].SetActive(true);
		CheckMode();
	}
	
	void CheckMode () {
		if (abilities[0].activeInHierarchy){
			inNormalMode = true;
			curAbilityNum = 0;
		} else {
			inNormalMode = false;
			curAbilityNum = abilityNum;
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
