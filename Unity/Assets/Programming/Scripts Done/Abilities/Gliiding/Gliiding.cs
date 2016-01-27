using UnityEngine;
using System.Collections;

public class Gliiding : MonoBehaviour {

	public Rigidbody 	rb;
	public Animator 	anim;
	public 	float 		oldMass;
	public 	float 		newMass;
	public GameObject 	glideEffect;

	void Start (){
		oldMass = rb.mass;
	}

	void Update () {
		if(Input.GetButton("Jump")){
			anim.SetBool("Glide", true);
			Instantiate(glideEffect, transform.position, Quaternion.identity);
			rb.mass = newMass;
		} 	
		if(!Input.GetButton("Jump")){
			if(rb.mass != oldMass){
				anim.SetBool("Glide", false);
				rb.mass = oldMass;
			}
		}
	}
}
