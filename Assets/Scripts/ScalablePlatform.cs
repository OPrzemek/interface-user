using UnityEngine;

enum ScalableType
{
    Increase = 1,
    Decrease = -1
}

public class ScalablePlatform : MonoBehaviour
{
    [SerializeField]
    private ScalableType scalableType = ScalableType.Increase;
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
        var finalScale = scalableType == ScalableType.Increase
            ? scaleValue
            : 1f / scaleValue;

        transform.localScale = originalScale * finalScale;
    }

}
