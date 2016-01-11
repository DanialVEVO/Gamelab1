using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiCollectScript : MonoBehaviour {

	public float	countdownTimer = 8f;
	public Vector2	uiInPosition = new Vector2(30, 0);
	public Vector2	uiOutPosition = new Vector2(-180, 0);
	public bool		canMoveOut = false;

	public Text text;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Timer ();
	}

	void Timer () {
		if(countdownTimer > 1){
			text.rectTransform.anchoredPosition = Vector2.Lerp(text.rectTransform.anchoredPosition, uiInPosition, .1f);
			countdownTimer -= Time.deltaTime;
		}

		if(countdownTimer < 1 && text.rectTransform.anchoredPosition.x >= uiOutPosition.x-5){
			text.rectTransform.anchoredPosition = Vector2.Lerp(text.rectTransform.anchoredPosition, uiOutPosition, .1f);
			if(text.rectTransform.anchoredPosition.x == uiOutPosition.x){
			}
		}
	}
}
