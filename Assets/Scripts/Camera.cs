using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Camera : MonoBehaviour
    {
        private Vector3 destination;
        private float speed = 2f;
        private bool m_toMove = false;

        private void Update()
        {
            // if (m_toMove)
            // {
                var step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, destination, step);
            //}
        }

        public void Move(float speed, Vector3 destination)
        {
            this.destination = destination;
            this.speed = speed;
            m_toMove = true;
        }
    }
}
