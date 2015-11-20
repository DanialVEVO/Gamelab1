/* 7S_Lilypads_001
 * Lilypads Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class LilypadScript : MonoBehaviour {

	public Transform[] lilypads;
	public float bottomHeight;
	public float speed;
	public float raiseTimer;
	public float dropTimer;

	private float topHeight;
	private float resRaiseTimer;
	private float resDropTimer;
	private int curLilypad;
	private int prevLilypad;
	
	void Start () {
		resDropTimer = dropTimer;
		resRaiseTimer = raiseTimer; 
		LilypadsMoveAllDown();
		bottomHeight = lilypads[0].position.y - bottomHeight;
		topHeight = lilypads[0].position.y;
	}

	void Update () {
		LilypadMove();
	}

	void LilypadMove () {
		if (curLilypad > 0) {
			prevLilypad = curLilypad -1;
		} else {
			prevLilypad = lilypads.Length -1;
		}

		raiseTimer -= Time.deltaTime;
		if (raiseTimer <= 0) {
			if (lilypads[curLilypad].position.y < topHeight){
				lilypads[curLilypad].position += new Vector3(0, 1 * speed * Time.deltaTime, 0);
			} else {
				dropTimer -= Time.deltaTime;
				if (dropTimer <= 0) {
					if (lilypads[prevLilypad].position.y > bottomHeight){
						lilypads[prevLilypad].position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
					} else {
						raiseTimer = resRaiseTimer;
						dropTimer = resDropTimer;
						if (curLilypad < lilypads.Length -1) {
							curLilypad++;
						} else {
							curLilypad = 0;
						}
					}
				}
			}
		}
	}

	void LilypadsMoveAllDown () {
		for (int i = 1; i < lilypads.Length; i++){
			lilypads[i].position -= new Vector3(0, bottomHeight, 0);
		}
	}
}
