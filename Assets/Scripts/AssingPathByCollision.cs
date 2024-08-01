using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssingPathByCollision : MonoBehaviour
{
    [SerializeField] private GameObject collisonDetector;
    [SerializeField] private GameObject platformOpenPoint;
    private bool isMovingPlatform = true;
    public float platformSpeed = 1.0f;
    private ActivatedMovementWithCollision platformToMoveScript;
    

    private void Start()
    {
        platformToMoveScript = collisonDetector.GetComponent<ActivatedMovementWithCollision>();
    }

    private void Update()
    {
        if (platformToMoveScript.isPlayerHere)
        {
            MovePlatform();
        }
    }


    private void MovePlatform()
    {
        if (isMovingPlatform)
        {
            transform.position = Vector3.MoveTowards(transform.position, platformOpenPoint.transform.position, platformSpeed * Time.deltaTime);
        }
        if (transform.position == platformOpenPoint.transform.position)
        {
            isMovingPlatform = false;
        }
    }
}
