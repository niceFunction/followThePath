using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//if necessary: youtu.be/sj5wsbC123U?list=PL5V9qxkY_RnK-QCLqEBX2JF6hh-F-HD6N

namespace SamuelEinheri.Cameras
{ 
    [CustomEditor(typeof(SE_TopDown_Camera))]
    public class SE_TopDownCamera_Editor : Editor
    {

        private SE_TopDown_Camera targetCamera;

        #region Main Methods
        private void OnEnable()
        {
            targetCamera = (SE_TopDown_Camera)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        private void OnSceneGUI()
        {
            // Do we have a Target?
            if(!targetCamera.m_Target)
            {
                return;
            }
            // Storing target reference
            Transform camTarget = targetCamera.m_Target;

            // Draw distance disc
            Handles.color = new Color(0f, 0f, 1f, 0.2f);
            Handles.DrawSolidDisc(targetCamera.m_Target.position, Vector3.up, targetCamera.m_Distance);

            Handles.color = new Color(0f, 0f, 1f, 1f);
            Handles.DrawWireDisc(targetCamera.m_Target.position, Vector3.up, targetCamera.m_Distance);

            // Create Slider handles to adjust camera properties
            Handles.color = new Color(0f, 0f, 1f, 0.5f);
            targetCamera.m_Distance = Handles.ScaleSlider(targetCamera.m_Distance, camTarget.position, -camTarget.forward, Quaternion.identity, targetCamera.m_Distance, 1f);
            targetCamera.m_Distance = Mathf.Clamp(targetCamera.m_Distance, 0f, float.MaxValue);

            Handles.color = new Color(0f, 1f, 0f, 0.5f);
            targetCamera.m_Distance = Handles.ScaleSlider(targetCamera.m_Distance, camTarget.position, camTarget.up, Quaternion.identity, targetCamera.m_Height, 1f);
            targetCamera.m_Height = Mathf.Clamp(targetCamera.m_Height, 2f, float.MaxValue);

            // Create Labels
            GUIStyle labelStyle = new GUIStyle();
            labelStyle.fontSize = 16;
            labelStyle.normal.textColor = Color.black;
            labelStyle.alignment = TextAnchor.UpperCenter;

            Handles.Label(camTarget.position + (-camTarget.forward * targetCamera.m_Distance), "Distance", labelStyle);
            Handles.Label(camTarget.position + (Vector3.up * targetCamera.m_Height), "Height", labelStyle);
        }
        #endregion

    }
}
