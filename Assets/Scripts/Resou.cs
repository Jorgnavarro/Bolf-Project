using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resou : MonoBehaviour

{
    public void OpenURL()
    {
        Application.OpenURL("https://www.canva.com/design/DAGMi3myCTA/h8InVrqmIOKMFbLxelv05A/edit?utm_content=DAGMi3myCTA&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton");
        Debug.Log("is this working");
    }    
}
