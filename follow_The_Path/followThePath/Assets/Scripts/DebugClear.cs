using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SamuelEinheri
{
    public class DebugClear : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ClearDistanceScore()
        {
            Debug.Log("Clearing highscore");
            PlayerPrefs.DeleteKey("DistanceScore");
            PlayerPrefs.Save();
        }
    }
}