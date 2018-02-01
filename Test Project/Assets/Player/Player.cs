using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 

public class Player : MonoBehaviour {


	public float horizontalSpeed = 3.0f;
	public float verticalSpeed = 3.0f;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = horizontalSpeed * CrossPlatformInputManager.GetAxis("Horizontal");
		float v = verticalSpeed * CrossPlatformInputManager.GetAxis("Vertical");
			
	}
}
