using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DectectWinZonePlayer : MonoBehaviour
{
    public bool IsPlayerInZone1;
    public bool IsPlayerInZone2;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WinZone1"))
        {
            IsPlayerInZone1 = true;
            Debug.Log(IsPlayerInZone1);
        }
        if (collision.gameObject.CompareTag("WinZone2"))
        {
            IsPlayerInZone2 = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("WinZone1"))
        {
            IsPlayerInZone1 = false;
        }
        if (collision.gameObject.CompareTag("WinZone2"))
        {
            IsPlayerInZone2 = false;
        }
    }

}
