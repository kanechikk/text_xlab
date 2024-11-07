using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class MainCamera : MonoBehaviour
    {
        private Vector3 destPos;
        private Quaternion destRot;
        private float speed = 2f;
        private bool m_toMove = false;

        private void Update()
        {
            if (m_toMove)
            {
                var step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, destPos, step);

                transform.rotation = Quaternion.Slerp(transform.rotation, destRot, step);

                //transform.rotation = Quaternion.Euler(destRot);

                if (transform.position == destPos && transform.rotation == destRot)
                {
                    m_toMove = false;
                }
            }
        }

        public void Move(float speed, Vector3 destination, Vector3 rotation)
        {
            destPos = destination;
            destRot = Quaternion.Euler(rotation);
            this.speed = speed;
            m_toMove = true;
        }
    }
}
