/* 7S_SAL_001
 * Save and Load Script
 * Scripted by Chantal
 */

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
class GameData {
	public int levelID;
	public List<int> enemies = new List<int>();
	public int collectables;
	public bool[] abilities;
	public int playerHP;
	public int playerLevens;
	public float playerMana;
	public float playerPositionX;
	public float playerPositionY;
	public float playerPositionZ;
}
