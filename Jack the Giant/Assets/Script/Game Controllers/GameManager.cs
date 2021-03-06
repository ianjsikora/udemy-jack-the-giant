﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDies;

	[HideInInspector]
	public int score, coinScore, lifeScore;

	// Use this for initialization
	void Awake () {
		MakeSingleton ();
	}

	void Start(){
		InitializeVariables ();
	}

	void OnEnable () {
		SceneManager.sceneLoaded += LevelFinishedLoading;
	}

	void OnDisable () {
		SceneManager.sceneLoaded -= LevelFinishedLoading;
	}

	void LevelFinishedLoading(Scene scene, LoadSceneMode mode){
		if (scene.name == "GameplayScene") {

			if (gameRestartedAfterPlayerDies) {
				GameplayController.instance.SetScore (score);
				GameplayController.instance.SetCoinScore (coinScore);
				GameplayController.instance.SetLifeScore (lifeScore);

				PlayerScore.scoreCount = score;
				PlayerScore.coinCount = coinScore;
				PlayerScore.lifeCount = lifeScore;
			} else if (gameStartedFromMainMenu) {
				GameplayController.instance.SetScore (0);
				GameplayController.instance.SetCoinScore (0);
				GameplayController.instance.SetLifeScore (2);

				PlayerScore.scoreCount = 0;
				PlayerScore.coinCount = 0;
				PlayerScore.lifeCount = 2;
							
			}
		}
	}

	void InitializeVariables (){

		if(!PlayerPrefs.HasKey ("Game Initialized")){
			
			GamePreferences.SetEasyDifficultyState (0);
			GamePreferences.SetEasyDifficultyCoinScore (0);
			GamePreferences.SetEasyDifficultyHighScore (0);

			GamePreferences.SetMediumDifficultyState (1);
			GamePreferences.SetMediumDifficultyCoinScore (0);
			GamePreferences.SetMediumDifficultyHighScore (0);

			GamePreferences.SetHardDifficultyState (0);
			GamePreferences.SetHardDifficultyCoinScore (0);
			GamePreferences.SetHardDifficultyHighScore (0);

			GamePreferences.SetMusicState (0);

			PlayerPrefs.SetInt ("Game Initialized", 1);
		}
	}

	void MakeSingleton () {  
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
		}
		DontDestroyOnLoad(gameObject);
	}

	public void CheckGameStatus(int score, int coinScore, int lifeScore) {

		if (lifeScore < 0) {
			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDies = false;

			GameplayController.instance.GameOverShowPanel (score, coinScore);
		} else {
			this.score = score;
			this.coinScore = coinScore;
			this.lifeScore = lifeScore;

			GameplayController.instance.SetScore (score);
			GameplayController.instance.SetScore (coinScore);
			GameplayController.instance.SetScore (lifeScore);

			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDies = true;

			GameplayController.instance.PlayerDiedRestartTheGame ();
		}
	}
}
