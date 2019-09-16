using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SamuelEinheri.Cameras
{ 
    public class SE_Camera_Menu : MonoBehaviour
    {
        [MenuItem("SamuelEinheri/Cameras/Top Down Camera")]
        public static void CreateTopDownCamera()
        {
            GameObject[] selectedGameObject = Selection.gameObjects;

            if(selectedGameObject.Length > 0 && selectedGameObject[0].GetComponent<Camera>())
            {
                if (selectedGameObject.Length < 2)
                {
                    AttachTopDownScript(selectedGameObject[0].gameObject, null);
                }
                else if(selectedGameObject.Length == 2)
                {
                    AttachTopDownScript(selectedGameObject[0].gameObject, selectedGameObject[1].transform);
                }
                else if(selectedGameObject.Length == 3)
                {
                    EditorUtility.DisplayDialog("Camera Tools", "You can only select 2 GameObjects in the Scene" +
                        " for this to work and the first selection needs to be a Camera!", "OK");
                }
            }
            else
            {
                EditorUtility.DisplayDialog("Camera Tools", "You need to select a GameObject in the Scene that has" + 
                    " a Camera component assigned to it!", "OK");
            }

        }
        static void AttachTopDownScript(GameObject aCamera, Transform aTarget)
        {
            // Assign Top down Script to the camera
            SE_TopDown_Camera cameraScript = null;
            if(aCamera)
            {
                cameraScript = aCamera.AddComponent<SE_TopDown_Camera>();
            

                // Check to see if we have a Target and we have a script reference
                if(cameraScript && aTarget)
                {
                    cameraScript.m_Target = aTarget;
                }

                Selection.activeGameObject = aCamera;
            }

        }
    }
}
