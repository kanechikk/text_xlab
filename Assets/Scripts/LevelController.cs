using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        private CreatingStones stones;

        [SerializeField]
        private float m_delay = 2f;
        private float m_timer;

        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
        }

        private void Update()
        {
            if (stones != null)
            {
                if (Time.time > m_timer + m_delay)
                {
                    m_timer = Time.time;
                    stones.StoneDrop();
                }
            }

        }
    }
}
