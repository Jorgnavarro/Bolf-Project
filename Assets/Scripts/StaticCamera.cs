using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCamera : MonoBehaviour
{
 public Transform player; // El transform de la bola
    public Vector3 offset;   // La posición relativa de la cámara respecto al jugador

    void LateUpdate()
    {
        if (player != null)
        {
            // posición de la cámara sin rotación en X
            Vector3 targetPosition = player.position + offset;



            // Mueve la cámara a la posición deseada
            transform.position = targetPosition;
        }
    }
}
