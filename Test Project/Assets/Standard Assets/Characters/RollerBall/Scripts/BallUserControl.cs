using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class BallUserControl : MonoBehaviour
    {
        private Ball ball; // Reference to the ball controller.

        private Vector3 move;

        private Transform cam; // A reference to the main camera in the scenes transform
        private Vector3 camForward; // The current forward direction of the camera
        private bool jump; // whether the jump button is currently pressed


        private void Awake()
        {
            ball = GetComponent<Ball>();


            if (Camera.main != null)
            {
                cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
            }
        }


        private void Update()
        {

            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            jump = CrossPlatformInputManager.GetButton("Jump");

            if (cam != null)
            {
            	//I do not understand how Vector3.Scale is used here. The docs say it multiplies the vectors together but even in the example I do not understand how they get to the 
            	//numbers presented in the documents. Normalized also escapes me as it says that the object keeps its direction but its length is 1. What does this mean? Maybe this
            	//Affects the lens of the camera so that it cannot distort.  
            	
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                move = (v*camForward + h*cam.right).normalized;
            }
            else
            {
                move = (v*Vector3.forward + h*Vector3.right).normalized;
            }
        }


        private void FixedUpdate()
        {
            ball.Move(move, jump);
            jump = false;
        }
    }
}
