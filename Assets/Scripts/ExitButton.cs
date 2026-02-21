using TMPro;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class ExitButton : MonoBehaviour
{
    [SerializeField] private TMP_Text[] exitText;
    [SerializeField] private CanvasGroup endPanel;
    [SerializeField] private GameObject cursor;

    private bool locked;

    void Start()
    {
        locked = false;

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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (locked) return;

        if (other.gameObject == cursor)
        {
            StartCoroutine(EndSequence());
        }
    }

    IEnumerator EndSequence()
    {
        endPanel.blocksRaycasts = true;

        float duration = 1f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            endPanel.alpha = timer / duration;
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        Application.Quit();
    }
}