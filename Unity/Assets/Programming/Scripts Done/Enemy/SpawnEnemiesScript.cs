/* 7S_???_001
 * Spawn Enemies Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class SpawnEnemiesScript : MonoBehaviour {

	public int spawnAmount;
	public GameObject enemy;
	public Vector3[] spawnPos;
	public Transform player;

	public void SpawnEnemies(){
		for (int i = 0; i < spawnAmount; i++){
			GameObject spawnedEnemy = Instantiate(enemy, spawnPos[i], transform.rotation) as GameObject;
			spawnedEnemy.transform.LookAt(player);
		}
	}
}
