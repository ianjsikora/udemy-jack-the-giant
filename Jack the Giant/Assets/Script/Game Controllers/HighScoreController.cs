﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreController : MonoBehaviour {

	[SerializeField]
	private string scoreText, coinText;

	// Use this for initialization
	void Start () {
		SetScoreBasedOnDifficulty ();
	}

	void SetScore (int score, int coinScore) {
		scoreText = score.ToString ();
		coinText = coinScore.ToString ();
	}

	void SetScoreBasedOnDifficulty (){

		if (GamePreferences.GetEasyDifficultyState () == 1) {
			SetScore(GamePreferences.GetEasyDifficultyHighScore(), GamePreferences.GetEasyDifficultyCoinScore());
		}else if (GamePreferences.GetMediumDifficultyState () == 1) {
			SetScore(GamePreferences.GetMediumDifficultyHighScore(), GamePreferences.GetMediumDifficultyCoinScore());
		}else if (GamePreferences.GetHardDifficultyState () == 1) {
			SetScore(GamePreferences.GetHardDifficultyHighScore(), GamePreferences.GetHardDifficultyCoinScore());
		}	

	}
	
	public void GoBackToMainMenu(){
		SceneManager.LoadScene ("MainMenuScene");
	}

}
