using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	public float smoothSpeed = 0125f;
	public float rotationSpeed = 5.0f;


	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;

	}

	// Update is called once per frame
	void LateUpdate () {

		Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
		offset = camTurnAngle * offset;

		Vector3 desiredPosition = player.transform.position + offset ;
		Vector3 smothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
		transform.position = smothedPosition;
		transform.LookAt (player.transform.position);
	}




}
