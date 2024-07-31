using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    public bool isDestroyed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You Destroy the Target");
            Destroy(gameObject);
            isDestroyed = true;
        }
    }
}
