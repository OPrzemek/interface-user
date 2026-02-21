using UnityEngine;

public class HowToPlayController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(GameManager.Instance.ShouldEnableHowToPlay);       
    }

    public void OnCloseButton()
    {
        GameManager.Instance.ShouldEnableHowToPlay = false;
        gameObject.SetActive(GameManager.Instance.ShouldEnableHowToPlay);
    }
}
