using UnityEngine;

public class Teletransportador : MonoBehaviour
{
    // Lista de posiciones predefinidas
    public Vector3[] posicionesPredefinidas;

    // Transform Jugador
    public Transform jugadorTransform;

    // Método para teletransportar al jugador a una posición específica
    public void Teletransportar(int indice)
    {
        if (indice >= 0 && indice < posicionesPredefinidas.Length)
        {
            // Teletransportar al jugador a la posición especificada
            jugadorTransform.position = posicionesPredefinidas[indice];
        }
        else
        {
            Debug.LogError("Índice fuera de rango. No se puede teletransportar.");
        }
    }
}

