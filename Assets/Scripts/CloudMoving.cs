using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoving : MonoBehaviour
{
    public float speed = 2;
    public Transform[] villagers_positions;
    private int dest_vil = 0;
    public ParticleSystem rain;
    void Update()
    {
        var step = speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rain.Stop();
            if(dest_vil == villagers_positions.Length - 1)
                dest_vil = 0;
            else
                dest_vil += 1;
        }

        var destination = new Vector3(villagers_positions[dest_vil].position.x, transform.position.y, villagers_positions[dest_vil].position.z);
        transform.position = Vector3.MoveTowards(transform.position, destination, step);

        if(transform.position == destination){
            rain.Play();
        }

    }
}
