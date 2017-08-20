using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences {

	public static string EasyDifficultyState = "EasyDifficultyState";
	public static string MediumDifficultyState = "MediumDifficultyState";
	public static string HardDifficultyState = "HardDifficultyState";

	public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
	public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
	public static string HardDifficultyHighScore = "HardDifficultyHighScore";

	public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
	public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
	public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

	public static string IsMusicOn = "IsMusicOn";

	// Note: will be using ints in the place of bools. 0 = false. 1 = true.
	public static void SetMusicState (int state){
		PlayerPrefs.SetInt (GamePreferences.IsMusicOn, state);
	}

	public static int GetMusicState (){
		return PlayerPrefs.GetInt (GamePreferences.IsMusicOn);
	}

	public static void SetEasyDifficultyState (int state) {
		PlayerPrefs.SetInt (GamePreferences.EasyDifficultyState, state);
	}

	public static int GetEasyDifficultyState () {
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficultyState);
	}

	public static void SetMediumDifficultyState (int state) {
		PlayerPrefs.SetInt (GamePreferences.MediumDifficultyState, state);
	}

	public static int GetMediumDifficultyState () {
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficultyState);
	}

	public static void SetHardDifficultyState (int state) {
		PlayerPrefs.SetInt (GamePreferences.HardDifficultyState, state);
	}

	public static int GetHardDifficultyState () {
		return PlayerPrefs.GetInt (GamePreferences.HardDifficultyState);
	}

	public static void SetEasyDifficultyHighScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.EasyDifficultyHighScore, score);
	}

	public static int GetEasyDifficultyHighScore () {
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficultyHighScore);
	}

	public static void SetMediumDifficultyHighScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.MediumDifficultyHighScore, score);
	}

	public static int GetMediumDifficultyHighScore () {
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficultyHighScore);
	}

	public static void SetHardDifficultyHighScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.HardDifficultyHighScore, score);
	}

	public static int GetHardDifficultyHighScore () {
		return PlayerPrefs.GetInt (GamePreferences.HardDifficultyHighScore);
	}

	public static void SetEasyDifficultyCoinScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.EasyDifficultyCoinScore, score);
	}

	public static int GetEasyDifficultyCoinScore () {
		return PlayerPrefs.GetInt (GamePreferences.EasyDifficultyCoinScore);
	}

	public static void SetMediumDifficultyCoinScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.MediumDifficultyCoinScore, score);
	}

	public static int GetMediumDifficultyCoinScore () {
		return PlayerPrefs.GetInt (GamePreferences.MediumDifficultyCoinScore);
	}

	public static void SetHardDifficultyCoinScore (int score) {
		PlayerPrefs.SetInt (GamePreferences.HardDifficultyCoinScore, score);
	}

	public static int GetHardDifficultyCoinScore () {
		return PlayerPrefs.GetInt (GamePreferences.HardDifficultyCoinScore);
	}

}
