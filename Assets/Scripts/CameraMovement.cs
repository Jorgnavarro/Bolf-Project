using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float velocidad = 10f;
    
    // Estructura array, limite izquierdo, limite derecho, limite inferior, limite superior, limite arriba, limite abajo
    private float[,] limitesNiveles = {
        { -20f, 20f, -20f, 20f, 20f, 2f },  // Nivel 1
        { -55f, 55f, 220f, 360f, 20f, 2f }   // Nivel 2
    };

    public Transform jugador; // Referencia al Transform del jugador
    public CameraController cameraController;
    private int nivelActual = 2;

    void Start()
    {
        // Posicionar la cámara en la posición inicial del jugador
        if (jugador != null)
        {
            transform.position = jugador.position;
        }
        else
        {
            Debug.LogWarning("El objeto jugador no está asignado.");
        }
    }

    void Update()
    {
        // Movimiento horizontal y vertical (X y Z)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Movimiento vertical (Y) con teclas Q y E
        float verticalY = 0f;
        if (Input.GetKey("q"))
        {
            verticalY = -1f; // Movimiento hacia abajo
        }
        else if (Input.GetKey("e"))
        {
            verticalY = 1f; // Movimiento hacia arriba
        }

        // Crear el vector de movimiento
        Vector3 movimiento = new Vector3(horizontal, verticalY, vertical) * velocidad * Time.deltaTime;

        // Calcular la nueva posición
        Vector3 nuevaPosicion = transform.position + movimiento;

        // Obtener los límites del nivel actual
        int nivelIndex = Mathf.Clamp(cameraController.nivelActual - 1, 0, limitesNiveles.GetLength(0) - 1);
        float limiteIzquierdo = limitesNiveles[nivelIndex, 0];
        float limiteDerecho = limitesNiveles[nivelIndex, 1];
        float limiteInferior = limitesNiveles[nivelIndex, 2];
        float limiteSuperior = limitesNiveles[nivelIndex, 3];
        float limiteArriba = limitesNiveles[nivelIndex, 4];
        float limiteAbajo = limitesNiveles[nivelIndex, 5];

        // Aplicar clamping a la nueva posición
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, limiteIzquierdo, limiteDerecho);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, limiteAbajo, limiteArriba);
        nuevaPosicion.z = Mathf.Clamp(nuevaPosicion.z, limiteInferior, limiteSuperior);

        // Aplicar la nueva posición a la cámara
        transform.position = nuevaPosicion;
    }
}
