using UnityEngine;

public class GolfBallController : MonoBehaviour
{
    

    public float forceMagnitude = 10f; // Magnitud de la fuerza aplicada
    private Rigidbody rbBall;

    void Start()
    {
        rbBall = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta el clic izquierdo del ratón
        {
            ApplyForceAtMousePosition();
        }
    }

    void ApplyForceAtMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                Vector3 forceDirection = -(hit.point - transform.position).normalized;
                rbBall.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
            }
        }
    }
}
