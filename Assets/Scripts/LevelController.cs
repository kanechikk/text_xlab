using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Stick stick;
        //public Basket basket;
        public CreatingStones appleSpawner;
        private float m_timer;
        [SerializeField]
        private float m_delay = 2f;
        private int m_score = 0;

        private List<Apple> m_apples = new List<Apple>();

        public event Action<int> onGameOver;
        public event Action<int> onScoreInc;

        public MainCamera cam;
        public GameObject mainMenuUI;
        public GameObject gamePlayUI;
        private UnityEngine.Vector3 destPosMainMenu = new UnityEngine.Vector3(61.85815f, 23.18307f, 52.0101f);
        private UnityEngine.Vector3 destRotMainMenu = new UnityEngine.Vector3(2.131f, -177.408f, 0.319f);
        private UnityEngine.Vector3 destPosGamePlay = new UnityEngine.Vector3(64.69865f, 23.54534f, 50.01152f);
        private UnityEngine.Vector3 destRotGamePlay = new UnityEngine.Vector3(5.84f, -69.226f, 0.613f);
        public float speedCam = 2f;

        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
            stick.onCollisionApple += OnCollisionStick;
            m_score = 0;

            ClearApples();
        }

        private void OnDisable()
        {
            if (stick)
            {
                stick.onCollisionApple -= OnCollisionStick;
            }
        }

        private void ClearApples()
        {
            foreach (var apple in m_apples)
            {
                Destroy(apple.gameObject);
            }

            m_apples.Clear();
        }

        private void Update()
        {
            if (Time.time > m_timer + m_delay)
            {
                m_timer = Time.time;

                var go = appleSpawner.StoneDrop();
                var apple = go.GetComponent<Apple>();

                apple.onCollisionApple += OnCollisionApple;
                apple.onTriggerApple += OnTriggerBasket;

                m_apples.Add(apple);
            }

            if(mainMenuUI.activeSelf == true)
            {
                cam.Move(speedCam, destPosMainMenu, destRotMainMenu);
            }

            if(gamePlayUI.activeSelf == true)
            {
                cam.Move(speedCam, destPosGamePlay, destRotGamePlay);
            }
        }

        private void OnTriggerBasket()
        {
            m_score++;
            Debug.Log($"score: {m_score}");
            onScoreInc?.Invoke(m_score);
        }

        private void OnCollisionStick()
        {
            //m_score++; 
            //Debug.Log($"score: {m_score}");
            //onScoreInc?.Invoke(m_score);
        }

        private void OnCollisionApple()
        {
            Debug.Log("GAME OVER!!!");
            onGameOver?.Invoke(m_score);
        }
    }
}
