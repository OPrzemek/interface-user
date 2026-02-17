using Config;
using UnityEngine;

public class MovingCredit : MonoBehaviour
{
    [SerializeField] private LetterConfig letterConfig;

    // SCROLL SETTINGS
    public float scrollSpeed = 1.5f;
    public float startY = -10f;
    public float resetY = 12f;

    private Vector3 startPos;

    string[] creditsLines = new string[]
    {
        "LEAD DEVELOPER",
        "EMDEMEISTER",
        "",
        "PROGRAMMING",
        "EMDEMEISTER",
        "J YUKESH",
        " ",
        "ART",
        "EMDEMEISTER",
        "J YUKESH",
        " ",
        "MUSIC",
        "SWAUDIO",
        " ",
        "GAME DESIGN",
        "EMDEMEISTER",
        " ",
        "SPECIAL THANKS",
        "THE PLAYER",
        "COFFEE",
        "STACKOVERFLOW",
        "THANKS FOR PLAYING",
        "Trap test for V"
    };

    private void Start()
    {
        // Set start position below screen
        startPos = new Vector3(transform.position.x, startY, transform.position.z);
        transform.position = startPos;

        // Spawn credits
        float y = 3f;

        foreach (string line in creditsLines)
        {
            InstantiateText(line, new Vector2(-4.5f, y), 0.4f);
            y -= 0.8f;
        }
    }

    private void Update()
    {
        // Move entire credits block up
        transform.Translate(Vector2.up * scrollSpeed * Time.deltaTime);

        // Reset when high enough
        if (transform.position.y >= resetY)
        {
            transform.position = startPos;
        }
    }

    private void InstantiateText(string text, Vector2 position, float scale = 1)
    {
        if (string.IsNullOrWhiteSpace(text))
            return;

        text = text.ToUpper();

        float positionX = position.x;

        GameObject parent = new GameObject(text);
        parent.transform.parent = transform; // IMPORTANT: parent to moving object
        parent.transform.localPosition = position;

        foreach (char c in text)
        {
            if (c == ' ')
            {
                positionX += 0.6f;
                continue;
            }

            if (c >= 'A' && c <= 'Z')
            {
                int index = c - 'A';
                GameObject prefab = letterConfig.Letters[index];

                Instantiate(prefab,
                            new Vector2(positionX, position.y),
                            Quaternion.identity,
                            parent.transform);

                positionX += 1f;
            }
        }

        parent.transform.localScale = Vector3.one * scale;
        parent.AddComponent<ScalablePlatform>();
        parent.name = text;
    }
}
