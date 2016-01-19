using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyWaveSpawner : MonoBehaviour {

public int waveNumber;


	private int enemySpawnCountPerWave = 5;
	private int spawnCount;


	public GameObject enemyPrefab;


	public Transform[] spawnLocations;


	public List<GameObject> enemys = new List<GameObject>();

	public bool readyForNextWave = false;


	public void SpawnWave (){
		GameObject stufToSpawn;
		spawnCount = CalculateNumberOfEnemys(enemySpawnCountPerWave);
		for(int i = 0 ; i <= spawnCount; i++){		
			stufToSpawn = Instantiate(enemyPrefab, spawnLocations[Random.Range(0, spawnLocations.Length)].position , Quaternion.identity) as GameObject;
			enemys.Add(stufToSpawn);
		}
		waveNumber ++;
	}

	int CalculateNumberOfEnemys (int _enemySpawnCount){
		int _spawnCount = (_enemySpawnCount * waveNumber);

		return _spawnCount;
	}

	public void CheckDeadEnemys (){
		for(int i = 0 ; i <= enemys.Count; i++){
			if(enemys[i] == null){
				readyForNextWave = false;
				break;
			}else{
				

			}
		}
	}

}
