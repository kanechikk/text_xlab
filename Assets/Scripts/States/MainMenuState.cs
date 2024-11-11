using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        public GameObject mainMenuUI;
        public GamePlayState gamePlayState;
        //public event Action<string> onToolChanged; 
        [SerializeField] private GameObject[] tools;
        //public TextMeshProUGUI scoreText;

        [SerializeField] private ToggleGroup toolOptions;

        private void OnEnable()
        {
            mainMenuUI.SetActive(true);

            foreach (GameObject tool in tools)
            {
                if (tool.name == GameInstance.tool)
                {
                    tool.SetActive(true);
                }
                else if (tool.activeSelf)
                {
                    tool.SetActive(false);
                }
            }
        }    

        public void SoundSettingsOn()
        {
            mainMenuUI.transform.GetChild(3).gameObject.SetActive(true);
        }

        public void SoundSettingsOff()
        {
            mainMenuUI.transform.GetChild(3).gameObject.SetActive(false);
        }

        public void CustomizationSettingsOn()
        {
            mainMenuUI.transform.GetChild(4).gameObject.SetActive(true);
        }

        // public void SubmitCustomizationSettings()
        // {
            
        // }

        public void CustomizationSettingsOff()
        {
            Toggle toggle = toolOptions.ActiveToggles().FirstOrDefault();
            PlayerPrefs.SetString("tool", $"{toggle.name}");
            //Debug.Log(toggle.name);
            ChangeTool(toggle.name);
            //onToolChanged?.Invoke(toggle.name);
            mainMenuUI.transform.GetChild(4).gameObject.SetActive(false);
        }

        private void ChangeTool(string name)
        {
            if (tools != null)
            {
                foreach (GameObject tool in tools)
                {
                    //Debug.Log(tool.name);
                    if (tool.name == name)
                    {
                        tool.SetActive(true);
                    }
                    else if (tool.activeSelf)
                    {
                        tool.SetActive(false);
                    }
                }
            }
        }

        private void OnDisable()
        {
            if(mainMenuUI)
            {
                mainMenuUI.SetActive(false);
            }
        }

        public void Play()
        {
            gameObject.SetActive(false);
            gamePlayState.gameObject.SetActive(true);
        }
    }
}
