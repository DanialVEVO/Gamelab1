using UnityEngine;
using System.Collections;

public class CloudStart : MonoBehaviour {

	public GameObject 	clouds;
	public Transform 	cloudStart;
	public GameObject 	curCouds;
	public Transform 	target;
	public float 		moveSpeed;
	public int 			numberOfClouds;
	public float 		timer;

	// Use this for initialization
	void Start () {
		Instantiate(clouds, cloudStart.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		print(numberOfClouds);
	
	}
	public void SpawnCloud (int cloudsToSpawn){
		for(int i = 0; i <= cloudsToSpawn ; i ++){
			Instantiate(clouds, cloudStart.position, Quaternion.identity);
			numberOfClouds --;
		}
	}
}
