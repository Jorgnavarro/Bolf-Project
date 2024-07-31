using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternetPlatform : MonoBehaviour
{
    public GameObject platform1; 
    public GameObject platform2; 
    public float switchInterval = 1.0f; // Intervalo de tiempo en segundos para cambiar entre plataformas

    private float timer;

    void Start()
    {
        platform1.SetActive(true);
        platform2.SetActive(false);
    }

    void Update()
    {
        // Cuenta el tiempo que ha pasado desde el último cambio
        timer += Time.deltaTime;

        // Si ha pasado el intervalo de tiempo, alterna las plataformas
        if (timer >= switchInterval)
        {
            // Alterna la activación de las plataformas
            bool isPlatform1Active = platform1.activeSelf;
            platform1.SetActive(!isPlatform1Active);
            platform2.SetActive(isPlatform1Active);

            // Reinicia el temporizador
            timer = 0f;
        }
    }
}
