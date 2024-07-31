using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movablePlatform : MonoBehaviour
{
    //necesitamos en escena asignar almenos dos puntos para que la plataforma se mueva
    public Transform[] waypoints;
    private int currentWaypoint = 0;  // Índice del punto de ruta actual
    private Rigidbody PlaneRb;

    [SerializeField] private int speed = 10;  

    // Start is called before the first frame update
    void Start()
    {
        PlaneRb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        // Obtener la dirección hacia el punto de ruta actual
        Vector3 targetPosition = waypoints[currentWaypoint].position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        transform.position += moveDirection * speed * Time.deltaTime;


        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Avanzar al siguiente punto de ruta
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }

    }
}
