using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    //GameObject del target - enemy
    [SerializeField] private GameObject target;
    //Game Object que contiene la posición B de la puerta
    [SerializeField] private GameObject doorOpenPoint;
    //Variable que almacena el script del Target
    private DestroyTarget targetScript;
    public float doorSpeed = 1.0f;
    //Booleano control puerta
    private bool isMovingDoor = true;
   
    


    private void Start()
    {
        //Inicialización del script del target para poder usar la variable
        targetScript = target.GetComponent<DestroyTarget>();
    }

    private void Update()
    {
        //Confirmación de target destruido para mover puerta
        if (targetScript.isDestroyed)
        {
            DoorOpen();
        }
    }


    public void DoorOpen()
    {
        if (isMovingDoor)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPoint.transform.position, doorSpeed * Time.deltaTime);
        }
        if(transform.position == doorOpenPoint.transform.position)
        {
            isMovingDoor = false;
        }
    }



}
