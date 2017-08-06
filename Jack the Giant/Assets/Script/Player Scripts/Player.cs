using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 8f, maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anim;

	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Using FixedUpate instead of Update. Update is called every frame. Fixed updated is called every few frames.
	void FixedUpdate () {
		PlayerMoveKeyboard ();
	}

	void PlayerMoveKeyboard () {
		float forceX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		// If negative, user input is left. If positive, user input is right.
		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {

			if (vel < maxVelocity) {
				forceX = speed;
			}
				
			Vector3 temp = transform.localScale;
			temp.x = 1.2f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);
			
		} else if (h < 0) {

			if (vel < maxVelocity) {
				forceX = -speed;
			}

			Vector3 temp = transform.localScale;
			temp.x = -1.2f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);
			
		} else {

			anim.SetBool ("Walk", false);
		
		}

		myBody.AddForce (new Vector2 (forceX, 0));
	
	}

}
