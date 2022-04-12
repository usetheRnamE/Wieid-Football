using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PauseSystem : MonoBehaviour
    {
        private bool isPaused;

        public GameObject pauseMenu;

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) OnPauseClick();            
        }
        public void OnPauseClick()
        {           
                isPaused = !isPaused;
                Time.timeScale = isPaused ? 0 : 1;
                pauseMenu.SetActive(isPaused);           
        }
    }
}
