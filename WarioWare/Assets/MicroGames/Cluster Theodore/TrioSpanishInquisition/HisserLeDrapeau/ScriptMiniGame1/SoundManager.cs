using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpanishInquisition
{
    namespace MiniGame1
    {
        public class SoundManager : MonoBehaviour
        {
            private AudioSource[] gameSounds;

            [SerializeField]
            private AudioSource goodButton;
            [SerializeField]
            private AudioSource wrongButton;
            [SerializeField]
            private AudioSource rFlag1;
            [SerializeField]
            private AudioSource rFlag2;
            [SerializeField]
            private AudioSource rFlag3;

            // Start is called before the first frame update
            void Start()
            {
                gameSounds = GetComponents<AudioSource>();

                goodButton = gameSounds[0];
                wrongButton = gameSounds[1];
                rFlag1 = gameSounds[2];
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

            public void PlayFlagFirst()
            {
                rFlag1.Play();
                Debug.Log("Drapeau satde 1");
            }
        }
    }
}
