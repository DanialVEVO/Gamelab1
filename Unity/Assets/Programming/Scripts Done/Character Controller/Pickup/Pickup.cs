using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pickup : MonoBehaviour {

	public int 			pickupCount;
	public int 			maxPickupCount;
	public Text 		pickupText;

	public float 		uiResetTimer;
	public GameObject	uiCollect;

	void OnTriggerEnter (Collider collision){
		if(collision.GetComponent<Collider>().tag == "Pickup"){
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