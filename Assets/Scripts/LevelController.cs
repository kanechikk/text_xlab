using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Stick stick;
        public CreatingStones appleSpawner;
        private float m_timer;
        [SerializeField]
        private float m_delay = 2f;
        private int m_score = 0;

        private List<Apple> m_apples = new List<Apple>();

        public event Action<int> onGameOver;
        public event Action<int> onScoreInc;

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

                apple.onCollisionApple += OnCollisionStone;

                m_apples.Add(apple);
            }

        }

        private void OnCollisionStick()
        {
            m_score++; 
            Debug.Log($"score: {m_score}");
            onScoreInc?.Invoke(m_score);
        }

        private void OnCollisionStone()
        {
            Debug.Log("GAME OVER!!!");
            onGameOver?.Invoke(m_score);
        }
    }
}
