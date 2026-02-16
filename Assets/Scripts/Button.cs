using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Button : MonoBehaviour
{
    [SerializeField]
    private SceneIndex sceneIndex;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        SceneManager.LoadScene((int)sceneIndex);
    }
}
