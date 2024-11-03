using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public CreatingStones stones;
    public CloudMoving cloud;

    private void Update()
    {
        if (stones != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                stones.StoneDrop();
            }
        }

        if (cloud != null)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                cloud.MoveNext();
            }
        }
    }
}
