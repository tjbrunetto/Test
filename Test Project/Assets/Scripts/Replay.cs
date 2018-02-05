using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 


public class Replay : MonoBehaviour {

	private const int bufferFrames = 10000; 
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
	
	private Rigidbody rigidyBody;
	private GameManager gameManager; 
	
	private bool recordToggle;
	private int startKeyFrame; 
	private int totalKeyFrame; 
	private int counterKeyFrame; 
	
	void Start () {
		rigidyBody = GetComponent<Rigidbody>();
		gameManager = GameObject.FindObjectOfType<GameManager>();
		recordToggle = !gameManager.recording; 
	}

	public void Record ()
	{
		if(recordToggle != gameManager.recording)
		{
		recordToggle = gameManager.recording; 
		rigidyBody.isKinematic = false; 
		startKeyFrame = Time.frameCount;
		}
		
		int keyFrame = Time.frameCount % bufferFrames;
		keyFrames [keyFrame] = new MyKeyFrame (Time.time, transform.position, transform.rotation);
	}
	
	void Update () {
		if(gameManager.recording){
		Record (); 
		} else {
			PlayBack();
		}
		
	}
	
	void PlayBack(){
	
	if(recordToggle != gameManager.recording)
	{
		recordToggle = gameManager.recording;
		rigidyBody.isKinematic = true; 
		
		int endKeyFrame = Time.frameCount;
		if((endKeyFrame - startKeyFrame) >= bufferFrames)
		{
		startKeyFrame = endKeyFrame + 1;
		
		totalKeyFrame = bufferFrames;
				
		
		} 
		else
		{
			totalKeyFrame = endKeyFrame - startKeyFrame; 
		}
		
		counterKeyFrame = 0; 
		
	}
	
		int keyFrame = (startKeyFrame + counterKeyFrame) % bufferFrames; 
		Debug.Log ("keyFrames[" + keyFrame + "].keyTime = " + keyFrames[keyFrame].frameTime); 
		
		
		transform.position = keyFrames[keyFrame].position; 
		transform.rotation = keyFrames[keyFrame].rotation; 
	
		counterKeyFrame ++;
		if(counterKeyFrame >= totalKeyFrame){
			counterKeyFrame = 0;
		}
	}


/// <summary>
/// A structure for storing time, rotation, and position.
/// </summary>
public struct MyKeyFrame{
	
	public float frameTime; 
	public Vector3 position;
	public Quaternion rotation; 
	
	public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation){
		frameTime = aTime; 
		position = aPosition;
		rotation = aRotation;
	
		} 
	}
}
