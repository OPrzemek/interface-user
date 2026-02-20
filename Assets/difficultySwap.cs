using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class difficultySwap : MonoBehaviour
{
    public GameObject Cursor;
    public DifficultySetting difficultySetting;
    public float diff;
    [SerializeField]
    private SceneIndex sceneIndex;

    public bool Locked = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Locked) return;
        if (other.gameObject == Cursor)
            difficultySetting.SetDifficulty(diff);
    }
}
