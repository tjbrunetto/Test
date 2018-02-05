using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

	public float Xmin, Xmax, Ymin, Ymax; 
	private GameObject player; 


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void LateUpdate () {
		transform.LookAt(player.transform) ;
		
		
	}
}
