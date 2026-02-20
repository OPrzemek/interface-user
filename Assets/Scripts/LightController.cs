using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    private Light2D originalLight;

    private void Awake()
    {
        originalLight = GetComponent<Light2D>();
    }

    private void Start()
    {
        ApplyLightIntensity(GameManager.Instance.BrightnessIntensity);
        ApplyColor(GameManager.Instance.VividColorValue);
    }

    public void ApplyLightIntensity(float scaleValue)
    {
        originalLight.intensity = scaleValue;
    }
    
    public void ApplyColor(float scaleValue)
    {
        // Inverted and normalized
        originalLight.color = new Color(1f, 1f, 1 - ((scaleValue - 1) / (255 - 1)), 1f);
    }
}
