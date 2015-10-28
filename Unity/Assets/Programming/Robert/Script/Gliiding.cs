using UnityEngine;
using System.Collections;

public class Gliiding : MonoBehaviour {

	private Rigidbody 	rb;

	public 	float 		oldMass;
	public 	float 		newMass;

	void Start (){
		rb =  GetComponent<Rigidbody>();
		oldMass = rb.mass;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Glide")){
			rb.mass = newMass;
		} 	
		if(!Input.GetButton("Glide")){
			if(rb.mass != oldMass){
				rb.mass = oldMass;
			}
		}
		//print(rb.mass);
	}
}
