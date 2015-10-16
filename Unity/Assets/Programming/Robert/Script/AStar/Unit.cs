using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Unit : Grid {


	public Transform target;
	public Vector3 oldTargetPos;
	public float speed = 20;
	Vector3[] path;
	int targetIndex;
	public float timersecs;

	IEnumerator Timer (){

		yield return new WaitForSeconds(timersecs);
		if(target.position != oldTargetPos){
			PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
			oldTargetPos = target.position;
		//print("timer");
		}
		StartCoroutine(Timer());
	}

	void Start() {
		oldTargetPos = target.position;
		PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
		StartCoroutine(Timer());
		
		//target = GameObject.FindWithTag("Player");

	}
	// private void ComparePos (Vector3 posA,Vector3 posB){
	// 	int compare = posA.CompareTo(posB);
	// 	return compare;
	// 	}
	// void Update (){
	// 	if(Input.GetButtonDown("Fire1")){
	// 		StartCoroutine(Timer());
	// 	}
	// }

	
	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];

		while (true) {
			if (transform.position == currentWaypoint) {
				targetIndex ++;
				if (targetIndex >= path.Length) {
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
			yield return null;

		}
	}

	public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex) {
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}
}