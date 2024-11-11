using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
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
        private float m_delay = 2.5f;
        private int m_score = 0;
        private int health = 3;

        private List<Apple> m_apples = new List<Apple>();

        public event Action<bool> onGameOver;
        public event Action<int> onScoreInc;
        public event Action<int> onHealthDec;

        [SerializeField] private AudioClip inBusketSound;
        [SerializeField] private AudioClip missSound;

        public int goal;

        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
            m_score = 0;
            health = 3;
            ClearApples();
            BeforeDropping();
        }

        private IEnumerator BeforeDropping()
        {
            yield return new WaitForSeconds(10f);
        }

        private void OnDisable()
        {
            if (m_apples.Count != 0)
            {
                ClearApples();
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

                //apple.onCollisionApple += OnCollisionApple;
                apple.onCollisionApple += OnCollisionGround;
                apple.onTriggerApple += OnTriggerBasket;

                m_apples.Add(apple);
            }
        }

        private void OnCollisionGround()
        {
            health--;
            onHealthDec?.Invoke(health);
            if (health == 0)
            {
                onGameOver?.Invoke(false);
            }
            else
            {
                SoundFXManager.instance.PlaySoundFXClip(missSound, transform, 1f);
            }
        }

        // private void GameOver()
        // {
        //     Debug.Log("GAME OVER!!!");
        //     onGameOver?.Invoke(false);
        // }

        private void OnTriggerBasket()
        {
            SoundFXManager.instance.PlaySoundFXClip(inBusketSound, transform, 1f);
            m_score++;
            onScoreInc?.Invoke(m_score);

            if (m_score == goal)
            {
                onGameOver?.Invoke(true);
            }
        }

        // private void OnCollisionStick()
        // {
        //     //m_score++; 
        //     //Debug.Log($"score: {m_score}");
        //     //onScoreInc?.Invoke(m_score);
        // }



        // private void OnCollisionApple()
        // {
        //     // Debug.Log("GAME OVER!!!");
        //     // onGameOver?.Invoke(m_score);
        // }
    }
}
