/* 
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public GameObject gameOverObj;

	void Start () {
		gameOverObj.SetActive(false);
	}

	public void ShowGameOverNotice () {
		gameOverObj.SetActive(true);
	}

	public void RemoveGameOverNotice () {
		gameOverObj.SetActive(false);
	}
}
