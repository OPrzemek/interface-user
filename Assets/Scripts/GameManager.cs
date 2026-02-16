using System.Collections.Generic;
using Config;
using UnityEngine;

enum SceneIndex
{
    MAIN_MENU = 0,
    SETTINGS_MENU = 1,
    CREDITS_MENU = 2
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float PlatformsScale = 1f;
    private float _gravityIncrement = 0f;
    private float _moveSpeedIncrement = 0f;
    
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    [SerializeField]
    private LetterConfig letterConfig;

    public void InstantiateText(string text, Vector2 position, float scale = 1)
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
        parent.AddComponent<ScalablePlatform>();
        parent.name = text;
    }
}
