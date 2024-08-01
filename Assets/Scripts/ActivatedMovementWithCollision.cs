using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedMovementWithCollision : MonoBehaviour
{
    public bool isPlayerHere;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerHere = true;
        }
    }
}
