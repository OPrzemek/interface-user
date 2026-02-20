using UnityEngine;

public class CatAnimController : MonoBehaviour
{
    [SerializeField]
    private bool _jump;
    [SerializeField]
    private bool _land;
    private bool _left;
    private bool _right;
    
    private Rigidbody2D _rb;
    private Animator _anim;
    private PlayerMovement _player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Left/right movement
        if (_rb.linearVelocity.x < -0.1f)
        {
            if (!_left)
            {
                _right = false;
                _left = true;
                transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            }
        }
        if (_rb.linearVelocity.x > 0.1f)
        {
            if (!_right)
            {
                _left = false;
                _right = true;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        // Run
        if (_rb.linearVelocity.x != 0f)
            _anim.SetBool("Run", true);
        else
            _anim.SetBool("Run", false);
        
        
        // Jump animation
        // Jump / Fall / Land logic
        if (!_player.IsGrounded())
        {
            // Rising
            if (_rb.linearVelocity.y > 0.2f)
            {
                _anim.SetBool("Jump", true);
                _anim.SetBool("Fall", false);
            }
            // Falling
            else if (_rb.linearVelocity.y < -0.2f)
            {
                _anim.SetBool("Jump", false);
                _anim.SetBool("Fall", true);
            }
        }
        else
        {
            // Landed
            _anim.SetBool("Jump", false);
            _anim.SetBool("Fall", false);
        }
    }
}
