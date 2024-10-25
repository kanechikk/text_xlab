using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingWeapon : MonoBehaviour
{
    public GameObject[] villagers_hands;
    public GameObject[] weapons;
    private GameObject cur_weap;
    private Vector3 pos, rot;

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int j = weapons.Length - 1; j > 0; j--)
            {
                cur_weap = weapons[j];
                weapons[j] = weapons[j - 1];
                weapons[j - 1] = cur_weap; 
            }

            pos = weapons[0].transform.position;
            rot = weapons[0].transform.eulerAngles;

            for(int i = 0; i < villagers_hands.Length; i++)
            {
                weapons[i].transform.parent = villagers_hands[i].transform;
                if(i == villagers_hands.Length - 1)
                {
                    weapons[i].transform.position = pos;
                    weapons[i].transform.eulerAngles = rot;
                }
                else
                {
                    weapons[i].transform.position = weapons[i + 1].transform.position;
                    weapons[i].transform.rotation = weapons[i + 1].transform.rotation;
                }

            }
        }
    }
}
