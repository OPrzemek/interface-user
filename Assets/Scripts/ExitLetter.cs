using System;
using UnityEngine;

enum Letter
{
    E = 0,
    X = 1,
    I = 2,
    T = 3
}

public class ExitLetter : MonoBehaviour
{
    [SerializeField]
    private Letter letter = Letter.E;

    private void Start()
    {
        // If already collected, remove
        if (GameManager.Instance.EXIT[(int)letter])
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Collect letter
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LetterCollected((int)letter);
            Destroy(gameObject);
        }
    }
}
