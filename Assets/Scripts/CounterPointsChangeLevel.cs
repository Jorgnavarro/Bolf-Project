using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterPointsChangeLevel : MonoBehaviour
{
    public int playerPoints = 0;

    private void Update()
    {
       if (playerPoints > 0)
        {
            ConditionWinLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ping"))
        {
            playerPoints += 10; 
        }
    }

    private void ConditionWinLevel()
    {
        if (playerPoints <= 30)
        {
            Debug.Log("You lose the game");
        }
        if (playerPoints > 30)
        {
            Debug.Log("You Pass the level");
        }
    }


}
