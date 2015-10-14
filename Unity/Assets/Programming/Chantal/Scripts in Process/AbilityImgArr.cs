/* 7S_TF_001
 * Ability Switch Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityImgArr : MonoBehaviour {

	public int stateNum;
	public AbilitySwitchScript abilitySwitchScr;


	void Start () {
		ShowImg();
	}


	public void ShowImg () {
		int switchAbilityNum = abilitySwitchScr.abilityNum;
		
		if (switchAbilityNum + stateNum < 0) {
			GetComponent<Image>().sprite = abilitySwitchScr.abilityImgSprArr[abilitySwitchScr.abilityImgSprArr.Length -1];
		} else if (switchAbilityNum + stateNum > abilitySwitchScr.abilityImgSprArr.Length - 1) {
			GetComponent<Image>().sprite = abilitySwitchScr.abilityImgSprArr[0];
		} else {
			GetComponent<Image>().sprite = abilitySwitchScr.abilityImgSprArr[switchAbilityNum + stateNum];
		}
	}
}
