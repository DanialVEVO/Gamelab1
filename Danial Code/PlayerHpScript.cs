﻿/* 7S_Hp_001
 * Player HP Script
 * Scripted by Danial & Chantal
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class PlayerHpScript : MonoBehaviour {
	public int totalMaxHP = 16;
	public int curMaxHearths = 8;
	public int curHP;
	public int maxHP;
	public int life = 3;
	public int startMaxHearts = 8;
	static public int shield = 1;
	public Text lifeText;
	public List<GameObject> heartSpots = new List<GameObject>();
	public List<GameObject> activeHeartSpots = new List<GameObject>();
	public GuiScript guiScr;
	public Transform player;
	public PlayerManager playerManagerScr;
	public GameObject gameOverObj;
	public SoundManagerScr soundManagerScr;
	private bool dead;


	void Start() {
		maxHP = curMaxHearths * 2;
		curHP = maxHP;
		SetHpInList();
		ShowNewMaxHealth(startMaxHearts);
		ShowLife();
		gameOverObj.SetActive(false);
	}

	public void GetDmg(int dmg) {
		if (!dead){
			dmg *= shield;
			if (curHP - dmg <= 0) {
				Dead();
			} else {
				int newHp = curHP - dmg;
				for (int myHp = curHP; myHp > newHp; myHp--) {
					curHP--;
					for (int i = curMaxHearths; i * 2 > curHP; i--) {
						if (curHP % 2 == 1) { //odd numbeers
							activeHeartSpots[i - 1].GetComponent<HeartFill>().halfHeartArr[1].SetActive(false);
						}
						if (curHP % 2 == 0) { //even numbers
							activeHeartSpots[i - 1].GetComponent<HeartFill>().halfHeartArr[0].SetActive(false);
						}
					}
				}
			}
		}
	}

	public void HealByAmount(int healAmount) {
		if (!dead){
			if (curHP + healAmount >= maxHP) {
				FullHeal();
	        } else {
				int newHp = curHP + healAmount;
				for (int myHp = curHP; myHp < newHp; myHp++) {
					curHP++;
					for (int i = 0; i * 2 < curHP; i++) {
						if (curHP % 2 == 1) { //odd numbeers
							activeHeartSpots[i].GetComponent<HeartFill>().halfHeartArr[0].SetActive(true);
						}
						if (curHP % 2 == 0) { //even numbers
							activeHeartSpots[i].GetComponent<HeartFill>().halfHeartArr[1].SetActive(true);
						}
					}
				}
			}
		}
	}

	public void LoseLife() {
		player.position = playerManagerScr.checkpoint.position;
		dead = false;
		life--;
		ShowLife();
		FullHeal();
	}

	public void Dead(){
		dead = true;
		guiScr.PanelSwitch(8);
		if (life > 0) {
			LoseLife();
		} else {
			gameOverObj.SetActive(true);
			soundManagerScr.Dead();
		}

	}

	public void ShowLife() {
		lifeText.text = "" + life;
	}

	public void ShowNewMaxHealth(int newCurMaxHearts) {
		curMaxHearths = newCurMaxHearts;

		for (int j = activeHeartSpots.Count; j < curMaxHearths; j++) {
			heartSpots[j].SetActive(true);
			activeHeartSpots.Add(heartSpots[j]);
		}
		FullHeal();
	}

	public void FullHeal() {
		curHP = curMaxHearths * 2;

		for (int i = 0; i < curMaxHearths; i++) {
			foreach (Transform child in activeHeartSpots[i].transform) {
				child.gameObject.SetActive(true);
			}
		}
	}

	void SetHpInList() {
		for (int heartNumber = 1; heartNumber <= totalMaxHP; heartNumber++) {
			GameObject heart = GameObject.Find("Heart (" + heartNumber + ")");
			heartSpots.Add(heart);
			heart.SetActive(false);
		}
	}

}
