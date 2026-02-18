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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
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
        if (_rb.linearVelocity.y > 0.2f)
        {
            if (!_jump)
            {
                _land = false;
                _jump = true;
                _anim.SetTrigger("Jump");
                _anim.SetBool("Idle", false);
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
        if (_rb.linearVelocity.y == 0f && _land)
        {
            _land = false;
            _anim.SetBool("Idle", true);
        }
    }
}
