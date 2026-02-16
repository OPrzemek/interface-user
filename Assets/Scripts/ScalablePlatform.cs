using UnityEngine;

public class ScalablePlatform : MonoBehaviour
{
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void Start()
    {
        ApplyScale(GameManager.Instance.PlatformsScale);
    }

    public void ApplyScale(float scaleValue)
    {
        transform.localScale = originalScale * scaleValue;
    }
}
