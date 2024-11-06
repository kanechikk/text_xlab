using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Golf
{
    public class Apple : MonoBehaviour
    {
        public event Action onCollisionApple;
        public bool isDirty = false;
        public bool inBusket = false;

        private void OnCollisionEnter(Collision other)
        {
            if (isDirty)
            {
                return;
            }

            if (other.gameObject.TryGetComponent<Apple>(out var apple))
            {
                apple.isDirty = true;

                onCollisionApple?.Invoke();
            }
        }
    }
}
