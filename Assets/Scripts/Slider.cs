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
    
    [SerializeField]
    private SliderType sliderType;

    private void Start()
    {
        switch (sliderType)
        {
            case SliderType.Scale:
                slider.value = GameManager.Instance.PlatformsScale;
                break;
            case SliderType.Gravity:
                slider.value = GameManager.Instance.GravityScale;
                break;
            case SliderType.MoveSpeed:
                slider.value = GameManager.Instance.MoveSpeed;
                break;
        }
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
    
    public void OnGravitySliderChanged(float value)
    {
        GameManager.Instance.GravityScale = value;

        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.rb.gravityScale = value;
    }
    
    public void OnMoveSpeedSliderChanged(float value)
    {
        GameManager.Instance.MoveSpeed = value;

        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.moveSpeed = value;
    }
}