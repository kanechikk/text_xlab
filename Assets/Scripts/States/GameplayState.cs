using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GamePlayState : MonoBehaviour
    {
        public GameOverState gameOverState;
        public PlayerController playerController;
        public LevelController levelController;
        public GameObject rootUI;
        public TMPro.TextMeshProUGUI scoreText;
        private GameObject healthBar;


        private void OnEnable()
        {
            rootUI.SetActive(true);
            playerController.enabled = true;
            levelController.enabled = true;
            gameOverState.isWin = false;

            healthBar = rootUI.transform.GetChild(0).gameObject;

            if (healthBar)
            {
                healthBar.transform.GetChild(0).gameObject.SetActive(true);
                healthBar.transform.GetChild(1).gameObject.SetActive(true);
                healthBar.transform.GetChild(2).gameObject.SetActive(true);
            }

            levelController.onGameOver += OnGameOver;
            levelController.onScoreInc += OnScoreInc;

            OnScoreInc(0);
        }

        private void Update()
        {
            levelController.onHealthDec += OnHealthDec;
        }


        private void OnDisable()
        {
            if (rootUI)
            {
                rootUI.SetActive(false);
            }

            if (playerController)
            {
                playerController.enabled = false;
            }
            
            if (levelController)
            {
                levelController.enabled = false;
                levelController.onGameOver -= OnGameOver;
                levelController.onScoreInc -= OnScoreInc;
            }
        }

        private void OnHealthDec(int health)
        {
            if (health == 2)
            {
                healthBar.transform.GetChild(0).gameObject.SetActive(false);
            }
            else if (health == 1)
            {
                healthBar.transform.GetChild(1).gameObject.SetActive(false);
            }
            else 
            {
                healthBar.transform.GetChild(2).gameObject.SetActive(false);
            }
        }

        private void OnScoreInc(int score)
        {
            scoreText.text = $"SCORE: {score}/{levelController.goal}";
        }

        private void OnGameOver(bool win)
        {
            gameObject.SetActive(false);
            
            if (win)
            {
                gameOverState.isWin = true;
            }
            else
            {
                gameOverState.isWin = false;
            }
            gameOverState.gameObject.SetActive(true);
        }
    }
}
