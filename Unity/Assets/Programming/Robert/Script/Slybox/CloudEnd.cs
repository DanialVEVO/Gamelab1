using UnityEngine;
using System.Collections;

public class CloudEnd : Cloud {


	void OnTriggerEnter(Collider cloud){
		print("lol");
		if(cloud.transform.tag == ("Cloud")){
			//cloud.transform.GetComponent<Cloud>().DestroyCloud();

			DestroyCloud(cloud.gameObject);
			numberOfClouds ++;
			CheckIfSpawnCloud();
		}
 	}

 	public void CheckIfSpawnCloud (){
 		SpawnCloud(numberOfClouds);
 	}
}
