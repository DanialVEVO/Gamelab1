/* 
 * Scripted by Chantal
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashScreenScr : MonoBehaviour {

	public GameObject mainCanvas;
	public GameObject logo;
	public GameObject splashScreen;
	public Sprite[] splashImg;
	public float logoTimer = 2f;
	public float splashTimer = 0.5f;
	public GameObject bgmManager;
	public AudioClip splashBgm;

	private int curSplash = 0;
	private float logoTimerRes;
	private float splashTimerRes;
	private bool startSplash = false;

	void Start () {
		bgmManager.GetComponent<AudioSource>().mute = true;
		mainCanvas.SetActive(false);
		splashTimerRes = splashTimer;
		logoTimerRes = logoTimer;
		splashScreen.SetActive(false);
		logo.SetActive(false);
	}

	void Update () {
		Logo();
		SplashScreens();
	}

	void Logo (){
		if(!startSplash){
			logoTimer -= Time.deltaTime;

			if (logoTimer <= 0){
				if (logo.activeInHierarchy == false){
					logo.SetActive(true);
					logoTimer = logoTimerRes;
				} else {
					startSplash = true;
					splashTimer = 0;
					bgmManager.GetComponent<AudioSource>().mute = false;
					bgmManager.GetComponent<AudioSource>().clip = splashBgm;
					bgmManager.GetComponent<AudioSource>().Play();
				}
			}
		}
	}

	void SplashScreens (){
		if(startSplash){
			splashScreen.SetActive(true);
			splashTimer -= Time.deltaTime;

			if (splashTimer <= 0){
				if(curSplash < splashImg.Length){
					splashScreen.GetComponent<Image>().sprite = splashImg[curSplash];
					splashTimer = splashTimerRes;
					curSplash++;
				} else{
					mainCanvas.SetActive(true);
					bgmManager.GetComponent<AudioSource>().clip = bgmManager.GetComponent<SoundManagerScr>().bgm[0];
					bgmManager.GetComponent<AudioSource>().Play();
					Destroy(gameObject);
				}
			}
		}
	}
}
