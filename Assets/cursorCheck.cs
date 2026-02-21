using UnityEngine;

public class CursorCheck : MonoBehaviour
{
    public GameObject cursor;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == cursor)
        {
            GameManager.Instance.PlayCursorClick();
            Debug.Log("cursorWorks");
        }
    }
}
