using UnityEngine;
using System.Collections;

public class ForInEditor : MonoBehaviour {

	void Awake(){
		GetComponent<MeshRenderer>().enabled = false;
	}
}
