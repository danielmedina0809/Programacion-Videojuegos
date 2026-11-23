using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 5.0f; //enemy detection radius 
    public float speed = 2.0f; //velocity of the enemy

    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() // on this function makes the enemy gets closer to the player
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            movement = new Vector2(direction.x,0);
        }
        else
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

    }

    void OnDrawGizmosSelected() //this function draws the radious detection of the enemy
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius); 
    }
}
