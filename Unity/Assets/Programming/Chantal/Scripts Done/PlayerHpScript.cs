/* 7S_Hp_001
 * Player HP Script
 * Scripted by Danial & Chantal
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class PlayerHpScript : MonoBehaviour {
	public int totalMaxHP;
	public int curMaxHearths;
	public int curHP;
	public int maxHP;
	public int life;
	public int startMaxHearts;
	public Text lifeText;
	public List<GameObject> heartSpots = new List<GameObject>();
	public List<GameObject> activeHeartSpots = new List<GameObject>();

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start() {
		maxHP = curMaxHearths * 2;
		curHP = maxHP;
		SetHpInList();
		ShowNewMaxHealth(startMaxHearts);
		ShowLife();
	}

	public void GetDmg(int dmg) {
		if (curHP - dmg <= 0) {
			LoseLife();
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

	public void HealByAmount(int healAmount) {
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

	public void LoseLife() {
		if (life > 0) {
			life--;
			ShowLife();
			FullHeal();
		} else {
			GameOver();
		}
	}

	public void ShowLife() {
		lifeText.text = "" + life;
	}

	public void GameOver() {
		//??????
		print("gameover");
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
