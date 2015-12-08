using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {
	
	public GameObject[] toHideOnStartMenu;
	
	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void Start () {
		HideObjects();
	}
	
	void OnLevelWasLoaded(int levelID) {
		if (levelID >= 1){
			UnhideObjects();
		}
	}
	
	void HideObjects(){
		for (int i = 0; i < toHideOnStartMenu.Length; i++){
			toHideOnStartMenu[i].SetActive(false);
		}
	}
	
	void UnhideObjects(){
		for (int i = 0; i < toHideOnStartMenu.Length; i++){
			toHideOnStartMenu[i].SetActive(true);
		}
	}	
}