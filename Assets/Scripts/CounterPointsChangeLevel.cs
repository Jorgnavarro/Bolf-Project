using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CounterPointsChangeLevel : MonoBehaviour
{
    [SerializeField] GameObject playerBall;
    [SerializeField] GameObject panelWin;
    [SerializeField] GameObject panelLose;

    private DectectWinZonePlayer scriptWinZoneFromPlayer;
    public int playerPointsLevel1 = 0;
    public int playerPointsLevel2 = 0;
    public float delayTime = 1.5f;
    public bool isPlayerInWinZone = false;
    private Vector3 changeToLevel2 = new Vector3(0f, 1.0f, 252.3665f);
    private bool isLevel1 = true;
    private float timer = 0f;

    private void Start()
    {
        scriptWinZoneFromPlayer = playerBall.GetComponent<DectectWinZonePlayer>();

        if (scriptWinZoneFromPlayer == null)
        {
            Debug.LogError("DectectWinZonePlayer component not found on the same GameObject.");
        }
    }

    private void Update()
    {
        if (isPlayerInWinZone)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                CheckWinCondition();
                timer = 0f; // Reinicia el temporizador
                isPlayerInWinZone = false; // Resetea la condición para evitar múltiples llamadas
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ping"))
        {
            if (isLevel1)
            {
                playerPointsLevel1 += 10;
                Debug.Log("Player points Level 1: " + playerPointsLevel1);
            }
            else
            {
                playerPointsLevel2 += 10;
                Debug.Log("Player points Level 2: " + playerPointsLevel2);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInWinZone = true;
            Debug.Log("Player entered win zone");
        }
    }

    private void CheckWinCondition()
    {
        if (isLevel1)
        {
            if (playerPointsLevel1 <= 30)
            {
                Debug.Log("You lose the game");
                panelLose.SetActive(true);
            }
            else
            {
                Debug.Log("You Pass the level");
                if (scriptWinZoneFromPlayer != null && scriptWinZoneFromPlayer.IsPlayerInZone1)
                {
                    Debug.Log("Player is in Zone 1, changing level...");
                    TransportPlayerToLevel2();
                }
            }
        }
        else
        {
            if (playerPointsLevel2 <= 30)
            {
                Debug.Log("You lose the game");
                panelLose.SetActive(true);
            }
            else
            {
                Debug.Log("You Pass the level");
                if (scriptWinZoneFromPlayer != null && scriptWinZoneFromPlayer.IsPlayerInZone2)
                {
                    PlayerVictory();
                }
            }
        }
    }

    private void TransportPlayerToLevel2()
    {
        playerPointsLevel1 = 0; // Reinicia los puntos del nivel 1
        isLevel1 = false; // Cambia al nivel 2
        playerBall.transform.position = changeToLevel2;
    }

    private void PlayerVictory()
    {
        panelWin.SetActive(true);
    }
}
