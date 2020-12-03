using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpanishInquisition
{
    namespace MiniGame1
    {
        public class LTN_SoundManager : MonoBehaviour
        {
            private AudioSource[] gameSounds;

            private AudioSource goodButton;
            private AudioSource wrongButton;

            // Start is called before the first frame update
            void Start()
            {
                gameSounds = GetComponents<AudioSource>();

                goodButton = gameSounds[0];
                wrongButton = gameSounds[1];
            }

            public void PlayGoodButton()
            {
                goodButton.Play();
                Debug.Log("Goodbutton play.");
            }

            public void PlayWrongButton()
            {
                wrongButton.Play();
                Debug.Log("WronButton play");
            }
        }
    }
}
