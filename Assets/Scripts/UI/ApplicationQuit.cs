using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ApplicationQuit : MonoBehaviour
    {
        public void OnQuitButtonPress()
        {
            Application.Quit();
        }
    }
}
