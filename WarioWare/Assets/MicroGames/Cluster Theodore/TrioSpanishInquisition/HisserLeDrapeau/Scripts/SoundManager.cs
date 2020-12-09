using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpanishInquisition
{
    namespace HisserLeDrapeau
    {
        public class SoundManager : MonoBehaviour
        {
            private AudioSource[] gameSounds;

            [SerializeField]
            private AudioSource goodButton;
            [SerializeField]
            private AudioSource wrongButton;
            [SerializeField]
            private AudioSource victorySound;
            [SerializeField]
            private AudioSource defeatSound;
            [SerializeField]
            private AudioSource rFlag1;
            [SerializeField]


            // Start is called before the first frame update
            void Start()
            {
                gameSounds = GetComponents<AudioSource>();

                goodButton = gameSounds[0];
                wrongButton = gameSounds[1];
                rFlag1 = gameSounds[2];
                victorySound = gameSounds[3];
                defeatSound = gameSounds[4];
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

            public void PlayVictory()
            {
                victorySound.Play();
                Debug.Log("Son Victoire");
            }

            public void PlayDefeat()
            {
                defeatSound.Play();
                Debug.Log("Son défaite");
            }
        }
    }
}
