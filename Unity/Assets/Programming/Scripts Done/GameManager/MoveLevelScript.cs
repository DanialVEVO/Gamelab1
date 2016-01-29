/* 7S_NXTL_001
 * Changing Level Scene Script
 * Scripted by Chantal
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveLevelScript : MonoBehaviour {

	public int nextLevelId;
	public GameObject splashScreen;
	public Sprite[] splashImg;
	public float splashTimer = 0f;
	private float splashTimerRes = 1f;
	private int curSplash = 0;

	void Start (){
	//	splashScreen = GameObject.Find("SplashImg");
		//splashScreen.SetActive(false);	
	}

	void OnCollisionEnter (Collision coll) {
	//	if (coll.gameObject.transform.tag == "Player"){
			GameObject enemiesListInScene = GameObject.FindWithTag("Enemies List");
			Destroy(enemiesListInScene);
	//		if (splashTimer <= 0){
		//		splashScreen.SetActive(true);
	//			if(curSplash < splashImg.Length){
	//				splashScreen.GetComponent<Image>().sprite = splashImg[curSplash];
	//				splashTimer = splashTimerRes;
	//				curSplash++;
	//			} else {
					Application.LoadLevel(nextLevelId);
		//		}
	//		}
	//	}
	}
}
