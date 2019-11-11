using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class DebugDisplay : MonoBehaviour
{

    //[HideInInspector]
    public Ball ball;

    float deltaTime = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        // Print FPS in Game/Editor
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string FPSText = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);

        // What Audio Clip is playing on the Ball
        string ballSourceText = string.Format("ballSource: " + ball.ballSource.clip.name.ToString());

        GUILayout.BeginVertical("box");
        GUILayout.Label(FPSText);
        GUILayout.Label(ballSourceText);
        GUILayout.EndVertical();
        
    }
}
