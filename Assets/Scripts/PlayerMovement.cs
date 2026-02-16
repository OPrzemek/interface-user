using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D _boxCollider2D;
    
    [SerializeField]
    private LayerMask whatIsGround;

    public float moveSpeed;
    private bool _isMoving;
    
    [SerializeField]
    private float maxJumpVelocity = 20;
    private float _currentJumpVelocity;

    private bool _jumped;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _jumped = false;
        _isMoving = false;
        moveSpeed = GameManager.Instance.MoveSpeed;
        rb.gravityScale = GameManager.Instance.GravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(horizontal) == 0f && _isMoving)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            _isMoving = false;
        }
        else
        {
            _isMoving = true;
            rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
        }
        // Jump
        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && !_jumped)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0.2f * rb.linearVelocity.y);
            _jumped = true;   
        }
        else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (_currentJumpVelocity < maxJumpVelocity)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, maxJumpVelocity);
                _currentJumpVelocity = rb.linearVelocity.y;
            }
            
        }
        if (IsGrounded())
        {
            _currentJumpVelocity = 0f;
            _jumped = false;
        }
    }
    
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size,
            0f, Vector2.down, 0.1f, whatIsGround);
        return hit.collider != null;
    }
}
