using UnityEngine;

public class StaticCamera : MonoBehaviour
{
    public Transform player; // Transform del jugador
    public float rotationSpeed = 100.0f; // Velocidad de rotación en grados por segundo

    void LateUpdate()
    {
        // Asegúrate de que el jugador esté asignado
        if (player == null)
        {
            Debug.LogWarning("Player transform is not assigned.");
            return;
        }

        // Rotar la cámara a la izquierda cuando se presiona "Q"
        if (Input.GetKey(KeyCode.Q))
        {
            RotateCamera(-rotationSpeed * Time.deltaTime);
        }

        // Rotar la cámara a la derecha cuando se presiona "E"
        if (Input.GetKey(KeyCode.E))
        {
            RotateCamera(rotationSpeed * Time.deltaTime);
        }
    }

    void RotateCamera(float angle)
    {
        // Rote la cámara alrededor del jugador en el eje Y
        transform.RotateAround(player.position, Vector3.up, angle);
    }
}
