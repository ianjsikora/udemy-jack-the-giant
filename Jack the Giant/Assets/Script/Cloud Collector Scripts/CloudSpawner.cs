﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] clouds;

	private float distanceBetweenClouds = 3f;

	private float minX, maxX;

	private float lastCloudPositionY;

	[SerializeField]
	private GameObject[] collectables;

	private float controlX;

	private GameObject player;

	// Use this for initialization
	void Awake () {
		controlX = 0;
		setMinAndMaxX ();
		CreateClouds ();
		player = GameObject.Find ("Player");

		for (int i = 0; i < collectables.Length; i++) {
			collectables [i].SetActive (false);
		}


	}

	void Start (){
		PositionThePlayer ();
	}

	void CreateClouds () {

		Shuffle (clouds);
		float positionY = 0f;

		for (int i = 0; i < clouds.Length; i++) {
			Vector3 temp = clouds [i].transform.position;
			temp.y = positionY;

			if (controlX == 0) {
				temp.x = Random.Range (0.0f, maxX);
				controlX = 1;
			} else if (controlX == 1) {
				temp.x = Random.Range (0.0f, minX);
				controlX = 2;
			} else if (controlX == 2) {
				temp.x = Random.Range(1.0f, maxX);
				controlX = 3;
			} else if (controlX == 3) {
				temp.x = Random.Range(-1.0f, minX);
				controlX = 0;
			}

			lastCloudPositionY = positionY;
			clouds [i].transform.position = temp;
			positionY -= distanceBetweenClouds;
		}
	}

	void Shuffle(GameObject[] arrayToShuffle) {

		for(int i = 0; i < arrayToShuffle.Length; i++) {
			GameObject temp = arrayToShuffle [i];
			int random = Random.Range (i, arrayToShuffle.Length);
			arrayToShuffle [i] = arrayToShuffle [random];
			arrayToShuffle [random] = temp;
		}
	}

	void setMinAndMaxX () {
		Vector3 bounds = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		maxX = bounds.x - 0.5f;
		minX = -bounds.x + 0.5f;
	}


	void PositionThePlayer () {
		GameObject[] darkClouds = GameObject.FindGameObjectsWithTag ("Deadly");
		GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag ("Cloud");

		for (int i = 0; i < darkClouds.Length; i++) {

			if (darkClouds [i].transform.position.y == 0f) {
				Vector3 t = darkClouds [i].transform.position;
				darkClouds[i].transform.position = new Vector3(
					cloudsInGame[0].transform.position.x,
					cloudsInGame[0].transform.position.y,
					cloudsInGame[0].transform.position.z
				);

				cloudsInGame[0].transform.position = t;
			}
		}

		Vector3 temp = cloudsInGame[0].transform.position;

		for (int i = 1; i < cloudsInGame.Length; i++) {
			if(temp.y < cloudsInGame[i].transform.position.y) {
				temp = cloudsInGame[i].transform.position;
			}
		}

		player.transform.position = new Vector3 (temp.x, temp.y + 0.8f, temp.z);

	}

	void OnTriggerEnter2D (Collider2D target) {

		if (target.tag == "Cloud" || target.tag == "Deadly") {
			
			if (target.transform.position.y == lastCloudPositionY) {

				Vector3 tempCloudPosition = target.transform.position;
				Shuffle (clouds);
				Shuffle (collectables);

				for (int i = 0; i < clouds.Length; i++) {
				
					if (!clouds[i].activeInHierarchy) {

						if (controlX == 0) {
							tempCloudPosition.x = Random.Range (0.0f, maxX);
							controlX = 1;
						} else if (controlX == 1) {
							tempCloudPosition.x = Random.Range (0.0f, minX);
							controlX = 2;
						} else if (controlX == 2) {
							tempCloudPosition.x = Random.Range(1.0f, maxX);
							controlX = 3;
						} else if (controlX == 3) {
							tempCloudPosition.x = Random.Range(-1.0f, minX);
							controlX = 0;
						}
					
						tempCloudPosition.y -= distanceBetweenClouds;
						lastCloudPositionY = tempCloudPosition.y;
						clouds[i].transform.position = tempCloudPosition;
						clouds[i].SetActive(true);

						int random = Random.Range (0, collectables.Length);

						if(clouds[i].tag != "Deadly") {

							if(!collectables[random].activeInHierarchy) {

								if(collectables[random].tag == "Life") {

									if(PlayerScore.lifeCount < 2) {
										collectables[random].SetActive(true);
										collectables[random].transform.position = new Vector3(clouds[i].transform.position.x,
											clouds[i].transform.position.y + 0.7f,
											clouds[i].transform.position.z);
									}
								}
								else {

									collectables[random].SetActive(true);
									collectables[random].transform.position = new Vector3(clouds[i].transform.position.x,
										clouds[i].transform.position.y + 0.7f,
										clouds[i].transform.position.z);
								}
							}
						}
					}
				}
			}
		}
	}
}
