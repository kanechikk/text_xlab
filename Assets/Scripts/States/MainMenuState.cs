using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        public GameObject mainMenuUI;
        public GameplayState gamePlayState;
        public TextMeshPro scoreText;

        private void OnEnable()
        {
            mainMenuUI.SetActive(true);
            //scoreText.text = $"TOP SCORE: {GameInstance.Score}"; 
        }

        private void OnDisable()
        {
            mainMenuUI.SetActive(false);
        }

        public void Play()
        {
            
        }
    }
}
