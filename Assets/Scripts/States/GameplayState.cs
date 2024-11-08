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
        private GameObject[] healthBar = new GameObject[3];

        private void OnEnable()
        {
            rootUI.SetActive(true);
            playerController.enabled = true;
            levelController.enabled = true;
            gameOverState.isWin = false;

            for (int i = 0; i < healthBar.Length; i++)
            {
                healthBar[i] = rootUI.transform.GetChild(i).gameObject;
                healthBar[i].SetActive(true);
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
                healthBar[0].SetActive(false);
            }
            else if (health == 1)
            {
                healthBar[1].SetActive(false);
            }
            else 
            {
                healthBar[2].SetActive(false);
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
            gameOverState.gameObject.SetActive(true);
        }
    }
}
