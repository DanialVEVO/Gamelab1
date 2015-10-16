using UnityEngine;
using System.Collections;

public class RockDestroy : MonoBehaviour {

	public float timer = 5;


	void Awake () {
		StartCoroutine(Timer());
	}
	
	IEnumerator Timer(){
		yield return new WaitForSeconds(timer);
		Object.Destroy(gameObject);		
	}

}
