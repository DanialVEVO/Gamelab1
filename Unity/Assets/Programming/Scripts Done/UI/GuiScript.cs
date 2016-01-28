﻿/* 7S_GUI_001
 * GUI Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class GuiScript : MonoBehaviour {
	
	public enum MenuPanels {
		MainMenu,       // 0
		GameMenu,       // 1
		Pause,          // 2
		Options,        // 3
		GameOptions,    // 4
		Credits,        // 5
		HelpScreen,     // 6
		GamePlay,       // 7
		Dying			// 8
	}
	
	public MenuPanels menuPanels;
	public GameObject[] menuObjArray;
	public bool inPause;
	public SaveLoadGameScript saveLoadGameScr;
	public AudioClip btSound;
	
	void Update() {
		PanelSwitchActive();
		SwitchPauseMode();
	}
	
	public void PanelSwitch(int newMenuPanel) {
		menuPanels = (MenuPanels)newMenuPanel;
		PanelSwitchActive();
	}
	
	void PanelSwitchActive() {
		MenuOff();
		switch (menuPanels) {
		case MenuPanels.MainMenu:
			menuObjArray[0].SetActive(true);
			break;
		case MenuPanels.GameMenu:
			menuObjArray[1].SetActive(true);
			break;
		case MenuPanels.Pause:
			menuObjArray[2].SetActive(true);
			break;
		case MenuPanels.Options:
			menuObjArray[3].SetActive(true);
			break;
		case MenuPanels.GameOptions:
			menuObjArray[4].SetActive(true);
			break;
		case MenuPanels.Credits:
			menuObjArray[5].SetActive(true);
			break;
		case MenuPanels.HelpScreen:
			menuObjArray[6].SetActive(true);
			break;
		}
	}
	
	void MenuOff() {
		for (int i = 0; i < menuObjArray.Length; i++) {
			menuObjArray[i].SetActive(false);
		}
	}
	
	public void ExitGame() {
		Application.Quit();
	}

	public void OpenMainMenu() {
		menuPanels = MenuPanels.MainMenu;
		Application.LoadLevel(0);
	}

	public void StartNewGame() {
		menuPanels = MenuPanels.GamePlay;
		Application.LoadLevel(1);
	}
	
	public void StartSavedGame() {
		menuPanels = MenuPanels.GamePlay;
		saveLoadGameScr.LoadGame();
	}
	
	public void SaveCurrentGame(){
		if (Application.loadedLevel != 0){
			saveLoadGameScr.SaveGame();
		}
	}
	
	public void SwitchPauseMode() {
		if (Input.GetButtonDown("Pause")) {
			if (inPause == false && menuPanels == MenuPanels.GamePlay) {
				PlayMenuSound();
				menuPanels = MenuPanels.Pause;
				Time.timeScale = 0;
				inPause = true;
			} else if (inPause == true){
				PlayMenuSound();
				menuPanels = MenuPanels.GamePlay;
				Time.timeScale = 1;
				inPause = false;
			}
		}
	}

	public void PlayMenuSound(){
		GetComponent<AudioSource>().PlayOneShot(btSound);
	}
}