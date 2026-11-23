using UnityEngine;

public class Moneda : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); //this makes that every object with this script it gets destroy when the character collition him
        }
    }
}
