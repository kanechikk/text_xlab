using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        public Strike strike;
        [SerializeField] private AudioClip strikeAudio;
        //public Stick stick;

        private void FixedUpdate()
        {
            // if (Input.GetMouseButton(0))
            // {
            //     stick.Down();
            // }
            // else
            // {
            //     stick.Up();
            // }

            // if (strike != null)
            // {
            //     if (Input.GetMouseButton(0))
            //     {
            //         strike.Forward();
            //     }
            // }
        }

        public void StrikeForward()
        {
            if (strike)
            {
                strike.Forward();
                SoundFXManager.instance.PlayMainSoundFXClip(strikeAudio, transform, 1f);
            }
        }
    }
}
