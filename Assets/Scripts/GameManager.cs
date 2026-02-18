using System.Collections.Generic;
using Config;
using UnityEngine;

enum SceneIndex
{
    MAIN_MENU = 0,
    SETTINGS_MENU = 1,
    CREDITS_MENU = 2,
    AUDIO_MENU = 3,
    ADVANCED_SETTINGS_MENU = 4,
    END_MENU = 5
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float PlatformsScale = 1f;
    public float GravityScale = 6f;
    public float MoveSpeed = 5f;
    public bool[] EXIT = { false, false, false, false };
    [SerializeField]
    private bool _exitUnlocked = false;
    
    
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

    public void LetterCollected(int letterIndex)
    {
        EXIT[letterIndex] = true;
        foreach (bool value in EXIT)
        {
            if (value == false)
            {
                _exitUnlocked = false;
                return;
            }
        }
        _exitUnlocked = true;
    }
}
