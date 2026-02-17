using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Button : MonoBehaviour
{
    public GameObject Cursor;
    [SerializeField]
    private SceneIndex sceneIndex;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject==Cursor)
        SceneManager.LoadScene((int)sceneIndex);
    }
}
