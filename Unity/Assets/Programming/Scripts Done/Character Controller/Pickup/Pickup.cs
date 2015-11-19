using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {

	public int pickupCount;
	public int maxPickupCount;
	public Text pickupText;

	void OnTriggerEnter (Collider collision){
		if(collision.GetComponent<Collider>().tag == "Pickup"){
			pickupCount ++;
			//print("pickupCount");
		}
	}
	void Update (){
		pickupText.text = pickupCount + "/" + maxPickupCount;
	}
}