using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCamera : MonoBehaviour
{
    public Transform ball; // El transform de la bola
    public Vector3 offset;   // La posición relativa de la cámara respecto a la bola
    public float rotationSpeed = 100f; // Velocidad de rotación de la cámara

    private float currentRotationY = 0f; // Rotación actual en el eje Y

    void LateUpdate()
    {
        if (ball != null)
        {
            // Rotación en Y con las teclas Q y E
            if (Input.GetKey(KeyCode.Q))
            {
                currentRotationY -= rotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.E))
            {
                currentRotationY += rotationSpeed * Time.deltaTime;
            }

            // Calcula la nueva posición de la cámara basada en la rotación alrededor de la bola
            Quaternion rotation = Quaternion.Euler(0, currentRotationY, 0);
            Vector3 rotatedOffset = rotation * offset;
            transform.position = ball.position + rotatedOffset;

            // Apunta la cámara hacia la bola
            transform.LookAt(ball.position);
        }
    }
}
