using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

	void Update(){
		if (transform.position.y <= -70.0f) {
			SceneManager.LoadScene("MiniGame");
		}


	}


	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		movement = Camera.main.transform.TransformDirection (movement);
		movement.y = 0.0f;	
		rb.AddForce (movement * speed);

	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			setCountText ();

		}
		if (other.gameObject.CompareTag ("GroundDoor") & (count >= 12)) {
			other.gameObject.SetActive (false);
		}
	}

	void setCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {

		}

		if (count >= 24) {
			winText.text = "Congratulations! You got all " + count.ToString() + " objects!";
	
			 

		}
	}
		

}
