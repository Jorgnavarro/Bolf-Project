using UnityEngine;

public class RockLoop : MonoBehaviour
{
    public GameObject[] rocks; // Array para los prefabs de las rocas
    public float spawnInterval = 3.0f; // Intervalo de tiempo entre spawns
    public float speed = 5.0f; // Velocidad de las rocas
    public float leftSpawnX = -10.0f; // Posición X de spawn izquierda ajustada
    public float rightHideX = 10.0f; // Posición X de esconder derecha
    public float spawnZ = 0.0f; // Posición Z de spawn

    private void Start()
    {
        // Empezar el bucle de spawn
        InvokeRepeating("SpawnRock", 0.0f, spawnInterval);
    }

    private void SpawnRock()
    {
        // Elegir una roca aleatoriamente del array
        GameObject rock = Instantiate(rocks[Random.Range(0, rocks.Length)], new Vector3(leftSpawnX, 0, spawnZ), Quaternion.identity);
        // Añadir el script de movimiento a la roca
        RockMovement rockMovement = rock.AddComponent<RockMovement>();
        rockMovement.speed = speed;
        rockMovement.rightHideX = rightHideX;
    }
}

public class RockMovement : MonoBehaviour
{
    public float speed;
    public float rightHideX;

    private void Update()
    {
        // Mover la roca hacia la derecha
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Destruir la roca cuando pase la posición de esconder
        if (transform.position.x > rightHideX)
        {
            Destroy(gameObject);
        }
    }
}
