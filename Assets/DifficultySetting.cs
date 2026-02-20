using UnityEngine;

public class DifficultySetting : MonoBehaviour
{
    public float difficulty = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetDifficulty(float value)
    {
        difficulty = value;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (difficulty == 0f)
        {
            transform.position=new Vector3(5f,-2f,0f);
        }
        if (difficulty == 0.5f)
        {
            transform.position = new Vector3(-5f, 2f, 0f);
        }
        if (difficulty == 1f)
        {
            transform.position = new Vector3(-20f, 8f, 0f);
        }
    }
}
