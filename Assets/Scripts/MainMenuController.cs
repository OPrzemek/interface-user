using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.InstantiateText("interface", new Vector2(-4.5f, 2), 1.2f);
        GameManager.Instance.InstantiateText("user", new Vector2(-2, 0), 0.7f);
        GameManager.Instance.InstantiateText("scale", new Vector2(-9f, 0.6f), 0.5f);
    }
}
