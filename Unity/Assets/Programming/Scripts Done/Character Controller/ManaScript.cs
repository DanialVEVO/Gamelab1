/* 7S_Mana_001
 * Mana Script
 * Scripted by Chantal
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaScript : MonoBehaviour {
	
	public AbilitySwitchScript abilitySwitchScr;
	
	public Slider manaBar;
	public float manaValue;
	private float maxMana;
	
	public float manaRegenTimer;
	private float manaRegenTimerRes;
	public float manaRegenGain;
	
	public float manaUseTimer;
	private float manaUseTimerRes;
	public float manaUseLose;
	
	public AudioClip emptyMana;
	
	void Start() {
		manaBar = GameObject.Find("Mana Bar").GetComponent<Slider>();
		manaValue = manaBar.value;
		maxMana = manaBar.maxValue;
		manaRegenTimerRes = manaRegenTimer;
		manaUseTimerRes = manaUseTimer;
	}
	
	void Update() {
		GainManaOverTime();
		LoseManaOverTime();
	}
	
	public void UseMana(float manaUsed) {
		if (manaValue >= manaUsed) {
			manaValue -= manaUsed;
		} else {
			GetComponent<AudioSource>().PlayOneShot(emptyMana);
		}
		manaBar.value = manaValue;
	}
	
	public void GainMana(float manaGain) {
		if (manaValue <= maxMana - manaGain) {
			manaValue += manaGain;
		} else {
			manaValue = maxMana;
		}
		manaBar.value = manaValue;
	}
	
	public void GainManaOverTime() {
		if (abilitySwitchScr.inNormalMode) { 
			if (maxMana >  manaValue + manaRegenGain){
				manaRegenTimer -= Time.deltaTime;
				
				if (manaRegenTimer <= 0) {
					manaValue += manaRegenGain;
					manaBar.value = manaValue;
					manaRegenTimer = manaRegenTimerRes;
				}
			} else if (maxMana <=  manaValue + manaRegenGain){
				manaValue = maxMana;
				manaBar.value = manaValue;
			} 
		} else {
			manaRegenTimer = manaRegenTimerRes;
		}
	}
	
	public void LoseManaOverTime() {
		if (!abilitySwitchScr.inNormalMode) { 
			if (manaValue > manaUseLose){
				manaUseTimer -= Time.deltaTime;
				
				if (manaUseTimer <= 0) {
					manaValue -= manaUseLose;
					manaBar.value = manaValue;
					manaUseTimer = manaUseTimerRes;
				}
			}else {
				manaUseTimer = manaUseTimerRes;
				abilitySwitchScr.abilityNum = 0;
				abilitySwitchScr.SetSwitchedAbility();
				abilitySwitchScr.GetAbilityImg();
			} 
		}	
	}
	
}
