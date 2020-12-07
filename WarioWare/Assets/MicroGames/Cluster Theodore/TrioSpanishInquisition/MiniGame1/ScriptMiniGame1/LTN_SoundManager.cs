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

            [SerializeField]
            private AudioSource goodButton;
            [SerializeField]
            private AudioSource wrongButton;
            private AudioSource flagRaise1;
            private AudioSource flagRaise2;
            private AudioSource flagRaise3;

            // Start is called before the first frame update
            void Start()
            {
                gameSounds = GetComponents<AudioSource>();

                goodButton = gameSounds[0];
                wrongButton = gameSounds[1];
                flagRaise1 = gameSounds[2];
                flagRaise2 = gameSounds[3];
                flagRaise3 = gameSounds[4];
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
