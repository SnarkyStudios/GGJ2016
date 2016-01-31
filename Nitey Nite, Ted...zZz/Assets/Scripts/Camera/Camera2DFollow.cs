using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;

        public float damping = 0.4f;
        public float lookAheadFactor = 5;
        public float lookAheadReturnSpeed = 0;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
		private float m_OffsetY;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;
		private float minX = 3.75f;
		private float maxX = 59.5f;
		private float maxY = 2.15f;

        // Use this for initialization
        private void Awake()
        {
			Application.targetFrameRate = 12;
			//Time.timeScale = 0.1f;

            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
			m_OffsetY = (transform.position - target.position).y;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

			Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ + Vector3.up*1.5f;

            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

			//minx
			newPos = new Vector3(Mathf.Max(newPos.x,minX),newPos.y,newPos.z);
			//maxX
			newPos = new Vector3(Mathf.Min(newPos.x,maxX),Mathf.Min(newPos.y,maxY),newPos.z);



			transform.position = newPos;

            m_LastTargetPosition = target.position;
        }
    }
}
