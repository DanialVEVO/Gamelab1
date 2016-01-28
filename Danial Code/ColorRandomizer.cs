using UnityEngine;
using System.Collections;

public class ColorRandomizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RandomizeColor();
	}

	void RandomizeColor(){
		gameObject.GetComponent<Renderer>().material.color = new Vector4(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),0f);
	}
}
