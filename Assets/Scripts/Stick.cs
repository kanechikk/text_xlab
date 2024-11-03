using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        public float maxAngle = 30f;
        public float speed = 360f;
        private bool m_isDown = false;

        public void Down()
        {
            m_isDown = false;
        }

        public void Up()
        {
            m_isDown = true;
        }

        private void FixedUpdate()
        {
            Vector3 angle = transform.localEulerAngles;
            if (m_isDown)
            {
                angle.x = Mathf.MoveTowardsAngle(angle.x, -maxAngle, speed * Time.deltaTime);
            }
            else 
            {
                angle.x = Mathf.MoveTowardsAngle(angle.x, maxAngle, speed * Time.deltaTime);
            }
            transform.localEulerAngles = angle;
        }
    }
}
