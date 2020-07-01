using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SamuelEinheri.UI
{
    public class PrintToConsole : MonoBehaviour, IActionable
    {
        [SerializeField, Tooltip("Will show a message in console")]
        private string message;

        public void Do(DoButton doButton)
        {
            Debug.Log(message);
        }
    }
}
