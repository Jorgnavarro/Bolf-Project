using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resou : MonoBehaviour

{
    public void OpenURL()
    {
        Application.OpenURL("https://www.canva.com/design/DAGMnZwWjYY/Rs8byuUA0jimOueSjlp3iQ/edit?utm_content=DAGMnZwWjYY&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton");
        Debug.Log("is this working");
    }    
}
