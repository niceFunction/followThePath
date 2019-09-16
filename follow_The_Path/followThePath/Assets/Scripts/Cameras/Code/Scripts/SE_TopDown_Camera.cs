using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SamuelEinheri.Cameras
{ 
    public class SE_TopDown_Camera : MonoBehaviour
    {
        /// <summary>
        /// " m_ " = member component of this script 
        /// </summary>
        public Transform m_Target;

        public float m_Height = 15f;
        public float m_Distance = 2f;

        [SerializeField]
        private float m_Angle = 0f;

        [SerializeField]
        private float m_SmoothSpeed = 0.15f;

        private Vector3 refVelocity;

        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {
            HandleCamera();
        }

        // Update is called once per frame
        void Update()
        {
            HandleCamera();
        }
        #endregion

        #region Helper Methods
        // Helper Methods
        protected virtual void HandleCamera()
        {
            if(m_Target)
            {
                if(!m_Target)
                {
                    return;
                }

                //TODO: Keep an eye on Vector3.forward and Vector3.up
                
                // Build World Position vector
                Vector3 worldPosition = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
                Debug.DrawLine(m_Target.position, worldPosition, Color.red);

                // Build Rotated vector
                Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPosition;
                Debug.DrawLine(m_Target.position, rotatedVector, Color.green);

                // Move Positioon
                Vector3 flatTargetPosition = m_Target.position;
                flatTargetPosition.y = 0f;
                Vector3 finalPosition = flatTargetPosition + rotatedVector;
                Debug.DrawLine(m_Target.position, finalPosition, Color.blue);

                transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_SmoothSpeed);
                //transform.LookAt(m_Target.position);

            }
        }

        private void OnDrawGizmos()
        {
            if(m_Target)
            {
                Gizmos.color = new Color(0f, 1f, 0f, 0.4f);
                Gizmos.DrawLine(transform.position, m_Target.position);
                Gizmos.DrawSphere(m_Target.position, 0.54f);
            }
            Gizmos.DrawSphere(transform.position, 1f);
        }
        #endregion
    }
}
