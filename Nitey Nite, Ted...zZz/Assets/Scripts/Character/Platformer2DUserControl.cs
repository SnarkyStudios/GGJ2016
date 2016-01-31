using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		private bool m_Blanket;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");

			if(h < 0.01f && h > -0.01f)
				m_Blanket = Input.GetKey(KeyCode.LeftShift);
			else if(m_Blanket)
				m_Blanket = Input.GetKey(KeyCode.LeftShift);
			
            // Pass all parameters to the character control script.
			m_Character.Move(h, crouch, m_Jump, m_Blanket);
            m_Jump = false;

			foreach(GameObject go in GameObject.FindGameObjectsWithTag("BGParalax")){
				go.transform.position = new Vector3(go.transform.position.x - (h/1000),go.transform.position.y,go.transform.position.z);
			}
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("FGParalax")){
				go.transform.position = new Vector3(go.transform.position.x - (h/1000),go.transform.position.y,go.transform.position.z);
			}
        }
    }
}
