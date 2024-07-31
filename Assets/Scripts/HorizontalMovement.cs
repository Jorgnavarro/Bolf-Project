using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public bool activate = false;
    //waypoints es un array donde almacenaremos varios puntos
    public GameObject[] waypoints;
    //platformSpeed velocidad de la plataforma
    public float platformSpeed = 2;
    //Index de nuestros waypoints para tener controlado en qu� punto nos encontramos
    //para luego ir al siguiente
    int waypointsIndex = 0;

    private void Update()
    {
        MoveObstacle();
    }


    public void MoveObstacle()
    {
        if (Vector3.Distance(transform.position, waypoints[waypointsIndex].transform.position) < 0.1f)
        {

            waypointsIndex++;

            if (waypointsIndex >= waypoints.Length)
            {
                waypointsIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].transform.position, platformSpeed * Time.deltaTime);
    }




}
