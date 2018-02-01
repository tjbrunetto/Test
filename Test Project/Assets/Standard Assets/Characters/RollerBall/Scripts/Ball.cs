using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Ball
{
    public class Ball : MonoBehaviour
    {
    	//Not Exactly sure what Serialize Field means here. I know that it adds things up in blocks, or one at a time. Not sure what the implication is though. 
    	
    	
        [SerializeField] private float m_MovePower = 50; // The force added to the ball to move it.
        [SerializeField] private bool m_UseTorque = true; // Whether or not to use torque to move the ball.
        [SerializeField] private float m_MaxAngularVelocity = 100; // The maximum velocity the ball can rotate at.
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.

        private const float k_GroundRayLength = 1f; // The length of the ray to check if the ball is grounded.
        private Rigidbody m_Rigidbody;


        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
        }


        public void Move(Vector3 moveDirection, bool jump)
        {
            if (m_UseTorque)
            {
            
            
            	//I have an idea that the -moveDirection is used because we do not want the ball to move into another axes?
            	// This is confusing though because we clamped the balls rotation in unity so that it cannot move into another axes.
            	// Then I start to think that maybe this is used to reverse the balls rotation but why would it be in the x direction and not the z direction. 
            	
            	
            	
                m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x)*m_MovePower);
            }
            else
            {
                m_Rigidbody.AddForce(moveDirection*m_MovePower);
            }
			
			
			
			// Again not exactly sure why we used the -Vector3.up here. I even removed it and played in unity. The ball would not jump.
			// I imagine this has to do with the fact that the ball needs to be touching the ground and thus should not have the ability to go up.
			//Then at the end of the code line && jump we add the next line which does not have the - in front of the Vector3.up.
			
			
			
            if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump)
            {
            
            
            	//Another new variable here is the ForceMode.Impulse. This is used to allow the ball to jump but I figured that jump power would do this for us. 
            	// I suppose that jump power is not strong enough or maybe is too slow and forcemode.Impulse is faster? 
            	// need some clarification on this. 
            	
            	
                m_Rigidbody.AddForce(Vector3.up*m_JumpPower, ForceMode.Impulse);
            }
        }
    }
}
