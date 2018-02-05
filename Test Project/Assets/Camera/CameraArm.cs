using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArm : MonoBehaviour {


	public float panSpeed = 5f;

	private GameObject player; 
	private Vector3 armRotation; 
		
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		armRotation = transform.rotation.eulerAngles; 
	}
	
	// Update is called once per frame
	void Update () {
		armRotation.x += Input.GetAxis ("Rvertical")* panSpeed; 
		armRotation.y += Input.GetAxis ("RHoriz")* panSpeed; 
		
		transform.position = player.transform.position; 
		transform.rotation = Quaternion.Euler(armRotation); 
	}
}
