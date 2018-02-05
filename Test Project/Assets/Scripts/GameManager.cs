using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 

public class GameManager : MonoBehaviour {


	public bool recording = true; 
	private float fixedDeltaTime; 
	private bool isPaused = false; 
	
	
	void Start(){
		PlayerPrefsManager.UnlockLevel(2);
		print (PlayerPrefsManager.IsLevelUnlocked(1));
		print (PlayerPrefsManager.IsLevelUnlocked(2));
		fixedDeltaTime = Time.fixedDeltaTime;
		print (fixedDeltaTime);
	
	}


	void Update () {
		if(CrossPlatformInputManager.GetButton("Fire1")){
			recording = false; 
		} else {
			recording = true; 
		}
		
		if(Input.GetKeyDown (KeyCode.P) && !isPaused){
			isPaused = true; 
			PauseGame();
		}else if(Input.GetKeyDown(KeyCode.P) && isPaused){
			isPaused = false; 
			UnpauseGame();
		
		}
		
	}
	
	void PauseGame(){
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}
	
	void UnpauseGame(){
		Time.timeScale = 1;
		Time.fixedDeltaTime = fixedDeltaTime; 
	
	}
	
	void OnApplicationPause(bool pauseStatus){
		isPaused = pauseStatus; 
	
	}
}
