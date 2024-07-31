using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitRestartPosition : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform playerBall;
    private Vector3 initialPosition = new Vector3(0.09f, 0.5f, 252.3665f);

    private void Start()
    {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //gameManager.GameDefined("JorgSpace");
            playerBall.transform.position = initialPosition;
        }
    }

}
