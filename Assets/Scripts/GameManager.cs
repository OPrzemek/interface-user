using System;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private LetterConfig letterConfig;

    private void Start()
    {
        InstantiateText("interface", new Vector2(-4.5f,2));
        InstantiateText("user", new Vector2(-2,0), 0.7f);
    }

    private void InstantiateText(string text, Vector2 position, float scale = 1)
    {
        text = text.ToUpper();
        float positionX = position.x + 0.5f;
        List<GameObject>  letters = new List<GameObject>();
        foreach (char c in text)
        {
            if (c >= 'A' && c <= 'Z')
            {
                int index = c - 'A';  // Converts letter to 0–25
                GameObject prefabToSpawn = letterConfig.Letters[index];
                letters.Add(prefabToSpawn);
            }
        }
        GameObject parent = Instantiate(new GameObject(), position + new Vector2(letters.Count / 2f, 0), Quaternion.identity);
        foreach (GameObject letter in letters)
        {
            Instantiate(letter, new Vector2(positionX, position.y), Quaternion.identity, parent.transform);
            positionX += 1;
        }
        parent.transform.localScale = new Vector3(scale, scale, scale);
    }
}
