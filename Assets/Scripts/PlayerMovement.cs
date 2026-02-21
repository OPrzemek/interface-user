using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D _boxCollider2D;
    
    [SerializeField]
    private LayerMask whatIsGround;

    private float timestamp;

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
        if (IsGrounded() && Time.time >= timestamp)
        {
            if (_jumped)
                _jumped = false;

            timestamp = Time.time + 0.3f;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !_jumped)
        {
            GameManager.Instance.PlayCatJump();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, maxJumpVelocity);
            _jumped = true;
        }
        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && rb.linearVelocity.y > 0f && _jumped)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0.2f * rb.linearVelocity.y);
        }
        
    }
    
    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size,
            0f, Vector2.down, 0.05f, whatIsGround);
        return hit.collider != null;
    }

    public void OnCatClick()
    {
        GameManager.Instance.PlayCatMeow();
    }
}
