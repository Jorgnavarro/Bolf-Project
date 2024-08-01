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
    public int playerPoints = 0;
    public float delayTime = 1.5f;
    public bool isPlayerInWinZone = false;
    private Vector3 changeToLevel2 = new Vector3(0f, 1.0f, 252.3665f);

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
        if (playerPoints > 0 && isPlayerInWinZone)
        {
            StartCoroutine(WaitAndCheckCondition());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ping"))
        {
            playerPoints += 10;
            Debug.Log("Player points: " + playerPoints);
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

    private IEnumerator WaitAndCheckCondition()
    {
        yield return new WaitForSeconds(delayTime);
        ConditionWinLevel();
    }

    private void ConditionWinLevel()
    {
        if (playerPoints <= 30)
        {
            Debug.Log("You lose the game");
            panelLose.SetActive(true);
        }
        else if (playerPoints > 30)
        {
            Debug.Log("You Pass the level");
            if (scriptWinZoneFromPlayer != null && scriptWinZoneFromPlayer.IsPlayerInZone1)
            {
                Debug.Log("Player is in Zone 1, changing level...");
                TransportPlayerToLevel1();
            }

            if(scriptWinZoneFromPlayer != null && scriptWinZoneFromPlayer.IsPlayerInZone2)
            {
                PlayerVictory();
            }
        }
    }

    private void TransportPlayerToLevel1()
    {
        playerPoints = 0;
        playerBall.transform.position = changeToLevel2;
    }

    private void PlayerVictory()
    {
        panelWin.SetActive(true);
    }


}
