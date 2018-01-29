﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private int count;
	public float speed;
	public Text countText;
	public Text winText;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		winText.text = " ";
		setCountText ();

	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
		}
	}

	void setCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "Congratulations! You got all " + count.ToString() + " objects!";
		}
	}
		

}