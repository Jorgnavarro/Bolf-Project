using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenDoorAbstraccion : MonoBehaviour
{
    [SerializeField] private Target[] target;
    [SerializeField] private Transform doorOpenPoint;
    public float doorSpeed = 1.0f;
    private bool isMovingDoor = true;

    private void Update()
    {
        if (AllTargetsDestroyed())
        {
            DoorOpen();
        }
    }

    private bool AllTargetsDestroyed()
    {
        foreach (var target in target)
        {
            if (!target.IsDestroyed)
            {
                return false;
            }
        }
        return true;
    }

    private void DoorOpen()
    {
        if (isMovingDoor)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPoint.position, doorSpeed * Time.deltaTime);
        }
        if (transform.position == doorOpenPoint.position)
        {
            isMovingDoor = false;
        }
    }

}
