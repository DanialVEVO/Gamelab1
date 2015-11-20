/* 7S_???_001
 * Managing living&dead enemies Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemiesManagerScript: MonoBehaviour {
	
	public GameObject[] enemiePrefab;
	public List<GameObject> enemiesInGame = new List<GameObject>();
	public List<int> enemiesAliveID = new List<int>();
	public List<Vector3> enemiesPos = new List<Vector3>();
	private Transform enemiesListInScene;
	private Transform spawnedEnemiesList;

	public int spawnID;
	
	/* enemiesAlive IDs
	 * 0 = Dead
	 * 1 = enemy kind 1
	 * 2 = enemy kind 2
	 * 3 = enemy kind 3
	 * Etc..
	 */
	
	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start () {
		enemiesListInScene = GameObject.FindWithTag("Enemies List").transform;
		FillEnemiesInGameList();
		FillVariables();
	//	SpawnedEnemies();
	}

	void OnLevelWasLoaded(int levelID) {
		enemiesInGame.Clear();
		enemiesAliveID.Clear();
		enemiesPos.Clear();
		enemiesListInScene = GameObject.FindWithTag("Enemies List").transform;
		enemiesListInScene.SetParent(transform);
		FillEnemiesInGameList();
		FillVariables();			
	}
	
	public void SpawnedEnemies(){
	//	spawnedEnemiesList = GameObject.Find("SpawnedEnemiesList" + spawnID).transform;
	//	spawnedEnemiesList.SetParent(transform);
	//	FillEnemiesInGameList();
	//	FillVariables();
	}
	
	public void FillEnemiesInGameList () {
		foreach (Transform child in transform){
			foreach (Transform subChild in child){
				if (subChild.tag == "Enemy"){
					enemiesInGame.Add(subChild.gameObject);
				}
			}
		}
	}
	
	void FillVariables (){
		for (int i = 0; i < enemiesInGame.Count; i++){
			enemiesAliveID.Add(enemiesInGame[i].GetComponent<EnemyIdScript>().enemyID);
			enemiesPos.Add(enemiesInGame[i].transform.position);
		}
	}
	
	public void CheckAlive(){
		for (int i = 0; i < enemiesInGame.Count; i++){
			if (enemiesInGame[i] == null){
				enemiesAliveID[i] = 0;
			} else {
				enemiesAliveID[i] = enemiesInGame[i].GetComponent<EnemyIdScript>().enemyID;
			}
		}
	}
	
	public void DestroyDead(){
		for (int i = 0; i < enemiesAliveID.Count; i++){
			if (enemiesAliveID[i] == 0){
				Destroy(enemiesInGame[i]);
			} else if (enemiesInGame[i] == null){
				GameObject spawnedEnemy = Instantiate(enemiePrefab[enemiesAliveID[i] -1], enemiesPos[i], transform.rotation) as GameObject;
				spawnedEnemy.transform.SetParent(enemiesListInScene);
			}
		}
	}
}
