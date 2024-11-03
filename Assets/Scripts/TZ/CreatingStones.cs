using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingStones : MonoBehaviour
{
    public GameObject stone;
    [SerializeField]
    private Transform m_point;

    private void Start()
    {
        if (m_point == null)
        {
            m_point = transform;
        }
    }

    public void StoneDrop()
    {
        Instantiate(stone, m_point.position, m_point.rotation);
    }
}
