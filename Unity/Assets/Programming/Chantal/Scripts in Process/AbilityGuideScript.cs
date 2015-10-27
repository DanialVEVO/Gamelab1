/* 7S_TTA_001
 * Ability guide Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class AbilityGuideScript : MonoBehaviour {
	public GameObject[] abilityGuideImg;

	void start () {
		for (int i = 0; i < abilityGuideImg.Length; i++){
			abilityGuideImg[i].SetActive(false);
		}
	}

	public void OpenAbilityGuide (int abilityId) {
		abilityGuideImg[abilityId].SetActive(true);
		Time.timeScale = 0;
	}

	public void CloseAbilityGuide () {
		for (int i = 0; i < abilityGuideImg.Length; i++){
			abilityGuideImg[i].SetActive(false);
		}
		Time.timeScale = 1;
	}
}
