using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Golf
{
    public class Apple : MonoBehaviour
    {
        public event Action onCollisionApple;
        public event Action onTriggerApple;
        public bool isDirty = false;
        public bool inBusket = false;

        private void OnCollisionEnter(Collision other)
        {
            if (isDirty)
            {
                return;
            }

            if (other.gameObject.TryGetComponent<Ground>(out var ground))
            {
                isDirty = true;

                onCollisionApple?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!inBusket)
            {
                inBusket = true;
                onTriggerApple?.Invoke();
            }
        }
    }
}
