﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {

	public int 			pickupCount;
	public int 			maxPickupCount;
	public Text 		pickupText;

	public float 		uiResetTimer;
	public GameObject	uiCollect;
	public GameObject	pickupEffect;
	public AudioClip 	pickupSound;

	void Start () {
		uiCollect = GameObject.Find("Collectables UI");
		pickupText = uiCollect.GetComponent<Text>();
	}

	void OnTriggerEnter (Collider collision){
		if(collision.GetComponent<Collider>().tag == "Pickup"){
			Instantiate(pickupEffect, collision.transform.position, Quaternion.identity);
			GetComponent<AudioSource>().PlayOneShot(pickupSound);
			uiCollect.GetComponent<UiCollectScript>().countdownTimer = uiResetTimer;
			pickupCount ++;
			//print("pickupCount");
			collision.GetComponent<FloatingObjectsScript>().DestroyThis();
		}
	}
	void Update (){
		pickupText.text = pickupCount + "/" + maxPickupCount;
	}
}