using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameInstance : MonoBehaviour
    {

        public Transform states;

        public static string tool = "Bat";

        private void OnEnable()
        {
            if (PlayerPrefs.HasKey("tool"))
            {
                tool = PlayerPrefs.GetString("tool");
            }

        }

        // public void OnDisable()
        // {
        //     PlayerPrefs.SetInt("TopScore", score);
        // }

        private void Start()
        {
            foreach (Transform child in states)
            {
                child.gameObject.SetActive(false);
            }

            states.GetChild(0).gameObject.SetActive(true);
        }
    }
}
