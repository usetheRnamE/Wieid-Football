using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerPanelPulse : MonoBehaviour
    {

        private Image img;

        private Color imgColor;

        private void OnEnable() { 
            img = GetComponent<Image>();

            imgColor = img.color;
            imgColor.a = 0;

            img.color = imgColor;

            StartCoroutine(TransparencyChange());
        }

        private IEnumerator TransparencyChange()
        {
            for (int i = 0; i < 3; i++)
            {
                imgColor.a = .45f;
                img.color = imgColor;

                yield return new WaitForSeconds(.3f);

                imgColor.a = 0;
                img.color = imgColor;

                yield return new WaitForSeconds(.3f);

                StartCoroutine(TransparencyChange());
            }

            this.gameObject.SetActive(false);   
        }
        private void OnDisable()
        {
            StopCoroutine(TransparencyChange());    
        }
    }
}
