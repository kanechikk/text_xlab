using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        public float maxAngle = 30f;
        public float speed = 360f;
        public float power = 100f;
        public Transform point;
        public event Action onCollisionApple;

        private Vector3 m_lastPointPosition;
        private Vector3 m_dir;
        private Rigidbody m_rigidbody;


        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            m_dir = (point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = point.position;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Apple>(out var apple) && !apple.isDirty)
            {
                apple.isDirty = true;
                //var contact = other.contacts[0];
                other.rigidbody.AddForce(m_dir * power, ForceMode.Impulse);
                other.rigidbody.drag = 1;
                onCollisionApple?.Invoke();
            }
        }
    }
}
