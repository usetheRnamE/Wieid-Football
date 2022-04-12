using Ball;
using GameOverSystem;
using System.Collections;
using TMPro;
using UnityEngine;

namespace GMOSystem
{
    public class GameOverSystem : MonoBehaviour
    {
        public GameObject GOMenu;

        public GameObject[] backgroundPanels;

        public TMP_Text text;
        private void Awake()
        {
            GOEventManager.GOEvent += OnGameOver;

            backgroundPanels[0].SetActive(false);
            backgroundPanels[1].SetActive(false);
        }
        private void OnGameOver()
        {
            BallPositionGetter();

            StartCoroutine(SetActiveGOMenu());
        }

        private IEnumerator SetActiveGOMenu()
        {
            yield return new WaitForSeconds(1);

            GOMenu.SetActive(true);
            StopCoroutine(SetActiveGOMenu());
        }

        private void BallPositionGetter()
        {
            float yPos = BallMovement.instance.transform.position.y;

            if (yPos < 0)
            {
                backgroundPanels[1].SetActive(true);

                text.color = Color.blue;
                text.text = "Blue team wins";
            }
            else if (yPos >= 0)
            {
                backgroundPanels[0].SetActive(true);

                text.color = Color.red;
                text.text = "Red team wins";
            }
        }
        private void OnDisable()
        {
            GOEventManager.GOEvent -= OnGameOver;
        }
    }
}
