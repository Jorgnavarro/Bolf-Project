using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float velocidad = 10f;
    public float limiteIzquierdo = -20f;
    public float limiteDerecho = 20f;
    public float limiteInferior = -20f;
    public float limiteSuperior = 20f;
    public float limiteArriba = 20f; // Agregado para limitar el movimiento hacia arriba
    public float limiteAbajo = 0f; // Agregado para limitar el movimiento hacia abajo

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

        // Aplicar límites a la nueva posición
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, limiteIzquierdo, limiteDerecho);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, limiteAbajo, limiteArriba); // Aplicar límite vertical Y
        nuevaPosicion.z = Mathf.Clamp(nuevaPosicion.z, limiteInferior, limiteSuperior);

        // Aplicar la nueva posición a la cámara
        transform.position = nuevaPosicion;
    }
}

