using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitRestartPosition : MonoBehaviour
{
    private Vector3 initialPositionLevel1 = new Vector3(0, 0.25f, 4.81f);
    private Vector3 initialPositionLevel2 = new Vector3(0.09f, 0.5f, 252.3665f);


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LimitLevel1"))
        { 
            transform.position = initialPositionLevel1;
        }

        if (other.gameObject.CompareTag("LimitLevel2"))
        {
            transform.position = initialPositionLevel2;
        }
    }

}
