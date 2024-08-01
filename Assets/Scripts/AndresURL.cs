using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndresURL : MonoBehaviour
{
     public void OpenURL()
    {
        Application.OpenURL("https://www.linkedin.com/in/andres-felipe-gomez-hernandez/");
        Debug.Log("is this working");
    }    
}

