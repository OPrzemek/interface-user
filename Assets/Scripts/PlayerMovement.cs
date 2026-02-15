using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider2D;
    
    [SerializeField]
    private LayerMask whatIsGround;
    
    [SerializeField]
    private float moveSpeed = 5;
    private bool _isMoving;
    
    [SerializeField]
    private float maxJumpVelocity = 20;
    private float _currentJumpVelocity;

    private bool _jumped;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _jumped = false;
        _isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(horizontal) == 0f && _isMoving)
        {
            _rb.linearVelocity = new Vector2(0f, _rb.linearVelocity.y);
            _isMoving = false;
        }
        else
        {
            _isMoving = true;
            _rb.linearVelocity = new Vector2(horizontal * moveSpeed, _rb.linearVelocity.y);
        }
        // Jump
        if (Input.GetKeyUp(KeyCode.Space) && !_jumped)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0.2f * _rb.linearVelocity.y);
            _jumped = true;   
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            if (_currentJumpVelocity < maxJumpVelocity)
            {
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, maxJumpVelocity);
                _currentJumpVelocity = _rb.linearVelocity.y;
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
