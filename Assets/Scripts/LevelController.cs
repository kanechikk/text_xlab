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
        public Ground ground;
        //public Basket basket;
        public CreatingStones appleSpawner;
        private float m_timer;
        [SerializeField]
        private float m_delay = 2f;
        private int m_score = 0;
        private int health = 3;

        private List<Apple> m_apples = new List<Apple>();

        public event Action<int> onGameOver;
        public event Action<int> onScoreInc;

        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
            m_score = 0;
            health = 3;

            ClearApples();
        }

        private void OnDisable()
        {
            ClearApples();
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

                //apple.onCollisionApple += OnCollisionApple;
                apple.onCollisionApple += OnCollisionGround;
                apple.onTriggerApple += OnTriggerBasket;

                m_apples.Add(apple);
            }
        }

        private void OnCollisionGround()
        {
            Debug.Log(health);
            health--;
            if (health == 0)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            Debug.Log("GAME OVER!!!");
            onGameOver?.Invoke(m_score);
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
            // Debug.Log("GAME OVER!!!");
            // onGameOver?.Invoke(m_score);
        }
    }
}
