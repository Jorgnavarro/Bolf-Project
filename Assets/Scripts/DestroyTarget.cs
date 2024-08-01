using UnityEngine;

public abstract class Target : MonoBehaviour
{
    public abstract bool IsDestroyed { get; }

}

public class DestroyTarget : Target
{
    public bool isDestroyed;
    public override bool IsDestroyed => isDestroyed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You Destroy the Target");
            Destroy(gameObject);
            isDestroyed = true;
        }
    }

}