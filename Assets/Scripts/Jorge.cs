using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jorge : MonoBehaviour
{
    public void OpenURL()
    {
        Application.OpenURL("https://www.linkedin.com/in/jorge-navarro-unity-developer/");
        Debug.Log("is this working");
    }    
}
