using UnityEngine;

public class DraggableController : MonoBehaviour
{
    private Rigidbody2D _selectedRb;
    private Vector2 _offset;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
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

    private void SelectObject()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            if (!hit.collider.CompareTag("DraggablePlatform")) return;
            _selectedRb = hit.collider.GetComponent<Rigidbody2D>();
            if (_selectedRb != null)
                _offset = mousePos - _selectedRb.position;
        }
    }
}
