using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Strike : MonoBehaviour
    {
        private Animator m_animator;

        private void Start()
        {
            m_animator = GetComponent<Animator>();
        }

        public void Forward()
        {
            m_animator.SetTrigger("TrStrike");
        }

        public void Backwards()
        {
            m_animator.SetTrigger("TrStrikeBackwards");
        }

        public void Idle()
        {
            m_animator.SetTrigger("TrIdle");
        }
    }
}
