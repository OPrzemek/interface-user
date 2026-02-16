using UnityEngine;
using UnityEngine.SceneManagement;

enum ButtonType
{
    MAIN_MENU = 0,
    SETTINGS_MENU = 1,
    CREDITS_MENU = 2
}

[RequireComponent(typeof(BoxCollider2D))]
public class Button : MonoBehaviour
{
    [SerializeField]
    private ButtonType buttonType;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        SceneManager.LoadScene((int)buttonType);
    }
}
