using System;
using UnityEngine;

enum InfoTextType
{
    PlayText,
    ExitText
}

public class InfoTextController : MonoBehaviour
{
    [SerializeField]
    private GameObject playText;
    [SerializeField]
    private GameObject exitText;
    
    [SerializeField]
    private InfoTextType infoTextType;
    [SerializeField]
    private GameObject cursor;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == cursor)
        {
            if (infoTextType == InfoTextType.PlayText && !playText.activeSelf)
            {
                playText.SetActive(true);
                Invoke(nameof(DisableText), 2f);
            }
            if (infoTextType == InfoTextType.ExitText && !exitText.activeSelf)
            {
                exitText.SetActive(true);
                Invoke(nameof(DisableText), 4f);
            }
        }
    }

    private void DisableText()
    {
        if (infoTextType == InfoTextType.PlayText)
            playText.SetActive(false);
        if (infoTextType == InfoTextType.ExitText)
            exitText.SetActive(false);
    }
}
