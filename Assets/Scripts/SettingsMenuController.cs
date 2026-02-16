using UnityEngine;

public class SettingsMenuController : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.InstantiateText("scale", new Vector2(-9f, 0.6f), 0.5f);
        GameManager.Instance.InstantiateText("gravity", new Vector2(-4f, 0.6f), 0.3f);
        GameManager.Instance.InstantiateText("move speed", new Vector2(1f, 0.6f), 0.3f);
    }
}
