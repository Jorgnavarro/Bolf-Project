using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitRestartPosition : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.GameDefined("JorgSpace");
        }
    }

}
