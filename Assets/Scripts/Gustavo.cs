using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gustavo : MonoBehaviour
{

    public void OpenURL()
    {
        Application.OpenURL("https://www.linkedin.com/in/ttavojimenez/");
        Debug.Log("is this working");
    }    
}
