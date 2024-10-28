using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingStones : MonoBehaviour
{
    public GameObject stone;

    public void StoneDrop()
    {
        Instantiate(stone, new Vector3(61, 40.3f, -45.3f), Quaternion.Euler(0, 0, 0));
    }
}
