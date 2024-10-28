using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoving : MonoBehaviour
{
    public float speed = 2;
    public Transform[] villagers_positions;
    private int dest_vil = 0;
    public ParticleSystem rain;


    private void Update()
    {
        var destination = GetDestination();
        var step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);

        if(transform.position == destination){
            rain.Play();
        }

        //Debug.Log("Апдейт работает");
    }

    private Vector3 GetDestination()
    {
        var destination = new Vector3(villagers_positions[dest_vil].position.x, transform.position.y, villagers_positions[dest_vil].position.z);
        return destination;
    }

    public void MoveNext()
    {
        //Debug.Log("Метод работает");
        rain.Stop();

        if(dest_vil == villagers_positions.Length - 1)
            dest_vil = 0;
        else
            dest_vil += 1;
    }
}
