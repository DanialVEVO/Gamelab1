using UnityEngine;
using System.Collections;

public class Cloud : CloudStart	 {
	public Transform curTarget;
	
	void Start(){
		curTarget = target;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards(transform.position, curTarget.position, moveSpeed * Time.deltaTime);
	}

	public void DestroyCloud (GameObject Cloud){
		print(Cloud.transform.name);
		Destroy(Cloud);
	}
}
