using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	[SerializeField]
	private Text scoreText, coinText, lifeText, gameoverScoreText, gameoverCoinText;

	[SerializeField]
	private GameObject pausePanel, gameoverPanel;

	[SerializeField]
	private GameObject readyButton;

	// Use this for initialization
	void Awake () {
		MakeInstance ();
	}

	void Start () {
		Time.timeScale = 0f;

	}
	
	void MakeInstance () {
		if (instance == null) {
			instance = this;
		}
	}

	public void GameOverShowPanel(int finalScore, int finalCoinScore) {
		gameoverPanel.SetActive (true);
		gameoverScoreText.text = finalScore.ToString ();
		gameoverCoinText.text = finalCoinScore.ToString ();
		StartCoroutine (GameOverLoadMainMenu ());
	}

	IEnumerator GameOverLoadMainMenu () {
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene ("MainMenuScene");
	}


	public void SetScore (int score) {
		scoreText.text = score.ToString();
	}

	public void SetCoinScore (int coinScore) {
		coinText.text = "x" + coinScore;
	}

	public void SetLifeScore (int lifeScore) {
		lifeText.text = "x" + lifeScore;

	}

	public void PauseTheGame(){
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
	}

	public void ResumeTheGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
	}

	public void QuitTheGame (){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenuScene");
	}

	public void StartTheGame (){
		Time.timeScale = 1f;
		readyButton.SetActive (false);
	}

}
