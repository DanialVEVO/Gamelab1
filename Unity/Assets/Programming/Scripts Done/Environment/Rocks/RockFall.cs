using UnityEngine;
using System.Collections;

public class RockFall : MonoBehaviour {

	public Transform 	spawnFrom;
	public GameObject 	rocks;
	public float 		timer;

	void Start () {
		StartCoroutine(Timer());
	}
	
	IEnumerator Timer (){
		yield return new WaitForSeconds(timer);
		Instantiate(rocks, spawnFrom.position, Quaternion.identity);	 
		StartCoroutine(Timer());
	}
}