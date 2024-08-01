using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miguel : MonoBehaviour
{

    public void OpenURL()
    {
        Application.OpenURL("https://www.linkedin.com/in/miguel-alejandro-palacio-gallego-gamedeveloper/");
        Debug.Log("is this working");
    }    
}

