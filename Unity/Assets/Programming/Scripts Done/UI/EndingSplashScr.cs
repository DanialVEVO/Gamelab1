using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndingSplashScr : MonoBehaviour {

	public GameObject splashScreen;
	public Sprite[] splashImg;
	public float splashTimer = 5f;
	public Pickup pickupScr;
	public GuiScript guiScr;
	public CanvasScript canvasScr;
	private bool startEndSplash = false;
	public int maxForBadEnding = 50;
	public int minForBestEnding = 126;


	void Start (){
		pickupScr = GameObject.Find("3D_SRH_001 (prefab v2)").GetComponent<Pickup>();
		guiScr = GameObject.Find("Menu").GetComponent<GuiScript>();
		canvasScr = GameObject.Find("Canvas (StartScene)").GetComponent<CanvasScript>();
		splashScreen.SetActive(false);
	}
	
	void Update () {
		if (startEndSplash){
			ShowSplash();
		}
	}

	void ShowSplash(){
		splashScreen.SetActive(true);

		splashTimer -= Time.deltaTime;
		if (pickupScr.pickupCount <= maxForBadEnding){
			splashScreen.GetComponent<Image>().sprite = splashImg[0];
		} else if (pickupScr.pickupCount >= minForBestEnding){
			splashScreen.GetComponent<Image>().sprite = splashImg[2];
		}else {
			splashScreen.GetComponent<Image>().sprite = splashImg[1];
		}

		if (splashTimer <= 0){
			guiScr.OpenMainMenu();
			canvasScr.HideObjects();
		}
	}

	void OnCollisionEnter (Collision coll) {
		startEndSplash = true;
	}
}
