using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(BoxCollider2D))]
public class Button : MonoBehaviour 
{ 
    public GameObject Cursor; 
    [SerializeField] 
    private SceneIndex sceneIndex; 
    public bool Locked = false; 
    public bool interactable 
    { get; internal set; } 
    private void OnCollisionEnter2D(Collision2D other) 
    { 
        if (Locked) return;
        if (other.gameObject == Cursor) 
            SceneManager.LoadScene((int)sceneIndex); 
    } 
}