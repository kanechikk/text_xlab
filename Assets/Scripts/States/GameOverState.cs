using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        public GameObject loseUI;
        public GameObject winUI;
        public MainMenuState mainMenuState;
        public GamePlayState gamePlayState;
        public bool isWin = false;

        private void OnEnable()
        {
            if (isWin)
            {
                winUI.SetActive(true);
            }
            else
            {
                loseUI.SetActive(true);   
            }     
        }

        private void OnDisable()
        {
            if (loseUI && !isWin)
            {
                loseUI.SetActive(false);
            }
            else if (winUI && isWin)
            {
                winUI.SetActive(false);
            }
        }
        
        public void Restart()
        {
            gameObject.SetActive(false);
            gamePlayState.gameObject.SetActive(true);
        }

        public void BackToManinMenu()
        {
            gameObject.SetActive(false);
            mainMenuState.gameObject.SetActive(true);
        }
    }
}
