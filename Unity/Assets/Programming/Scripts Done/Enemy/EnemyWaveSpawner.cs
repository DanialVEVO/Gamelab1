//using UnityEngine;
//using System.Collections;
//
//public class EnemyWaveSpawner : MonoBehaviour {
//
//public int waveNumber;
//
//
//	private int enemySpawnCountPerWave = 5;
//	private int spawnCount;
//
//
//	public GameObject enemyPrefab;
//
//
//	public Transform[] spawnLocations;
//
//
//	public List<GameObject> _list = new List<GameObject>();
//
//
//	public void SpawnWave (){
//		GameObject stufToSpawn;
//		spawnCount = CalculateNumberOfEnemys(enemySpawnCountPerWave);
//		for(int i = 0 ; i <= spawnCount; i++){		
//			stufToSpawn = Instantiate(enemyPrefab, spawnLocations[Random.Range(0, spawnLocations.Length).position , Quaternion.identity) as GameObject;
//			_list.Add(stufToSpawn);
//		}
//		waveNumber ++;
//	}
//
//	int CalculateNumberOfEnemys (int _enemySpawnCount){
//		int spawnCount = (_enemySpawnCount * waveNumber);
//
//		return spawnCount;
//	}
//
//}
