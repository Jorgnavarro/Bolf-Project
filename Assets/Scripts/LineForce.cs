using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineForce : MonoBehaviour
{

    //L�nea que renderizamos para tiro
    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] private float stopVelocity = .05f;

    [SerializeField] private float shootPower;
    [SerializeField] ParticleSystem polvoParticula;

    private Rigidbody rbBall;

    private bool isIdle;

    private bool isAiming;


    private void Awake()
    {
        rbBall = GetComponent<Rigidbody>();
        isAiming = false;
        lineRenderer.enabled = false;
    }
    private void OnMouseDown()
    {
        //Al hacer click comprobamos si el objeto est� activo, sino apuntamos
        if (isIdle)
        {
            isAiming = true;
        }
    }

    private void FixedUpdate()
    {
        if (rbBall.velocity.magnitude < stopVelocity)
        {
            Stop();
        }
        ProcessAim();
    }

    private void Stop()
    {
        rbBall.velocity = Vector3.zero;
        rbBall.angularVelocity = Vector3.zero;
        isIdle = true;
    }

    private void ProcessAim()
    {
        if (!isAiming || !isIdle)
        {
            return;
        }

        Vector3? worldPoint = CastMouseClickRay();
        if (!worldPoint.HasValue)
        {
            return;
        }
        //Se dibujar� la l�nea
        DrawLine(worldPoint.Value);

        if (Input.GetMouseButtonUp(0))
        {
            Shoot(worldPoint.Value);
        }
    }

    private void Shoot(Vector3 worldPoint)
    {
        isAiming = false;
        lineRenderer.enabled = false;
        //Que siempre sea la trayectoria en vertical
        //Vector3 horizontalWorldPoint = new Vector3(-worldPoint.x, transform.position.y, -worldPoint.z);
        //Vector3 direction = (horizontalWorldPoint - transform.position).normalized;
        Vector3 direction = (transform.position - worldPoint).normalized;
        float strength = Vector3.Distance(transform.position, worldPoint);
        //fuerza del tiro
        rbBall.AddForce(direction * strength * shootPower);

        //Para que no se pueda disparar varias veces
        isIdle = false;
        Instantiate(polvoParticula, transform.position, transform.rotation);
        SoundManager.Instance.soundManagerVFX.PlayOneShot(SoundManager.Instance.sonidosGolpes[1]);


    }

    //Funci�n que dibuja la escena en la l�nea
    private void DrawLine(Vector3 worldPoint)
    {
        //Configuraci�n de la l�nea con respecto al gameObject y la ubicaci�n del click del mouse
        Vector3[] positions = { transform.position, worldPoint };

        lineRenderer.SetPositions(positions);

        lineRenderer.enabled = true;
    }

    //Funci�n que mide los planos en donde est� ubicado nuestro click
    private Vector3? CastMouseClickRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane
            );
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        if(Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, float.PositiveInfinity))
        {
            return hit.point;
        }
        else
        {
            return null;
        }

    }
}
