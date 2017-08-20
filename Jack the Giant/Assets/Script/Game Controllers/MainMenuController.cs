using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void StartGame(){
		GameManager.instance.gameStartedFromMainMenu = true;
		SceneManager.LoadScene ("GameplayScene");
	}

	public void HighScoreMenu(){
		SceneManager.LoadScene ("HighScoreMenuScene");
	}

	public void OptionsMenu(){
		SceneManager.LoadScene ("OptionsMenuScene");
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void MusicButton (){
	
	}
		
}
