using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Camera fixedCamera; // Cámara fija al jugador
    public Camera movableCamera; // Cámara movible

    private bool useFixedCamera = true; // Controla qué cámara está activa

    void Start()
    {
        
        fixedCamera.gameObject.SetActive(true);
        movableCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        // Cambiar entre cámaras con la tecla 'space'
        if (Input.GetKeyDown(KeyCode.Space))
        {
            useFixedCamera = !useFixedCamera; // Alternar entre cámaras
            fixedCamera.gameObject.SetActive(useFixedCamera);
            movableCamera.gameObject.SetActive(!useFixedCamera);
        }
    }
}
