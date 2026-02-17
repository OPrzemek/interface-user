using UnityEngine;

public class CatAnimController : MonoBehaviour
{
    private bool _jump;
    private bool _land;
    private bool _idle;
    private bool _left;
    private bool _right;
    
    private Rigidbody2D _rb;
    private Animator _anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _jump = false;
        _land = false;
        _idle = false;
        _left = false;
        _right = false;
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
        
        
        // Jump animation
        if (_rb.linearVelocity.y > 0.2f)
        {
            if (!_jump)
            {
                _land = false;
                _idle = false;
                _jump = true;
                _anim.SetTrigger("Jump");
            }
        }
        if (_rb.linearVelocity.y < -0.2f)
        {
            if (!_land)
            {
                _jump = false;
                _land = true;
                _anim.SetTrigger("Land");
            }
        }
        if (_rb.linearVelocity.y > -0.2f && _land)
        {
            if (!_idle)
            {
                _land = false;
                _idle = true;
                _anim.SetTrigger("Idle");
            }
        }
    }
}
