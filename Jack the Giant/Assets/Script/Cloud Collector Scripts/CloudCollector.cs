using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D Target) {

		if (Target.tag == "Cloud" || Target.tag == "Deadly") {
		
			Target.gameObject.SetActive (false);

		}

	}
		
}
