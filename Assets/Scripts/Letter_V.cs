using UnityEngine;

public class Letter_V : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool PlayerDown = false;
    public BoxCollider2D mainCollider;
    public GameObject Player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.gravityScale = 0;
        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;
        PlayerDown = false;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (rb == null) return;
        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
        if (hit.collider != null && hit.collider.gameObject == Player)
        {
            PlayerDown = true;
        }

        if (PlayerDown && rb != null)
        {
            rb.gravityScale = 1;
            rb.isKinematic = false;
            
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb == null) return;

        if (collision.otherCollider == mainCollider)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = true;
            PlayerDown = false;
        }
        
    }
}
