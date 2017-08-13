using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {

	void OnEnable (){
		Invoke ("DestroyCollectable", 6f);
	} 


	void OnDisable (){


	} 

	void DestroyCollectable (){
		gameObject.SetActive (false);
	}

}
