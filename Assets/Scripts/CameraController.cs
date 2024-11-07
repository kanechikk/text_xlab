using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class CameraController : MonoBehaviour
    {
        public MainCamera cam;
        public GameObject mainMenuUI;
        public GameObject gamePlayUI;
        private UnityEngine.Vector3 destPosMainMenu = new UnityEngine.Vector3(61.85815f, 23.18307f, 52.0101f);
        private UnityEngine.Vector3 destRotMainMenu = new UnityEngine.Vector3(2.131f, -177.408f, 0.319f);
        private UnityEngine.Vector3 destPosGamePlay = new UnityEngine.Vector3(64.69865f, 23.54534f, 50.01152f);
        private UnityEngine.Vector3 destRotGamePlay = new UnityEngine.Vector3(5.84f, -69.226f, 0.613f);
        public float speedCam = 2f;

        private void Update()
        {
            if(mainMenuUI.activeSelf == true)
            {
                cam.Move(speedCam, destPosMainMenu, destRotMainMenu);
            }

            if(gamePlayUI.activeSelf == true)
            {
                cam.Move(speedCam, destPosGamePlay, destRotGamePlay);
            }
        }
    }
}
