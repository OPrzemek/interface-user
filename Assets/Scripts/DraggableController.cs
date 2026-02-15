using UnityEngine;

public class DraggableController : MonoBehaviour
{
    private Rigidbody2D _selectedRb;
    private Collider2D _collider;
    private Vector2 _offset;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _collider = SelectObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_collider != null)
                _collider.enabled = true;
            _selectedRb = null;
        }
    }

    void FixedUpdate()
    {
        if (_selectedRb != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _selectedRb.MovePosition(mousePos - _offset);
        }
    }

    private Collider2D SelectObject()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            if (!hit.collider.CompareTag("DraggablePlatform"))
                return null;
            _selectedRb = hit.collider.GetComponent<Rigidbody2D>();
            if (_selectedRb != null)
            {
                hit.collider.enabled = false;
                _offset = mousePos - _selectedRb.position;
                return hit.collider;
            }
        }
        return null;
    }
}
