using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameOverSystem {
    public class GOEventManager : MonoBehaviour
    {
        public static event Action GOEvent;

        public TMP_Text tmpText;

        private float timeToCountDown;

        private void Start()
        {
            timeToCountDown = Random.Range(10, 40);

            StartCoroutine(TimeCountDown());
        }

        private IEnumerator TimeCountDown()
        {
            while (timeToCountDown > 0)
            {
                tmpText.text = timeToCountDown.ToString();
                timeToCountDown--;

                if (timeToCountDown <= 0)
                    break;

                yield return new WaitForSeconds(1);
            }

            tmpText.gameObject.SetActive(false);

            GOEvent?.Invoke();

            StopCoroutine(TimeCountDown());
        }

    }
}

