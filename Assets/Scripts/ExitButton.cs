using TMPro;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text[] exitText;

    private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        var locked = false;
        for (int i = 0; i < GameManager.Instance.EXIT.Length; i++)
        {
            if (GameManager.Instance.EXIT[i])
                exitText[i].color = Color.green;
            else
            {
                exitText[i].color = Color.white;
                locked = true;
            }
        }

        button.Locked = locked;
    }
}
