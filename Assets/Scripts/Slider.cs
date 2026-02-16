using System;
using UnityEngine;
using UnityEngine.UI;

enum SliderType
{
    Scale,
    Gravity,
    MoveSpeed
}

public class Slider : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Slider slider;

    private void Start()
    {
        slider.value = GameManager.Instance.PlatformsScale;
    }

    public void OnScaleSliderChanged(float value)
    {
        GameManager.Instance.PlatformsScale = value;

        ScalablePlatform[] platforms = FindObjectsOfType<ScalablePlatform>();

        foreach (var platform in platforms)
        {
            platform.ApplyScale(value);
        }
    }
}