using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Basket : MonoBehaviour
    {
        public event Action onTriggerApple;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Apple>(out var apple) && !apple.inBusket)
            {
                apple.inBusket = true;
                onTriggerApple?.Invoke();
            }
        }
    }
}
