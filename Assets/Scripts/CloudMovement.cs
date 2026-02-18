using UnityEngine;

enum CloudDirection
{
    Left = -1,
    Right = 1
}

public class CloudMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private CloudDirection direction = CloudDirection.Left;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3((int)direction * speed * Time.deltaTime, 0f, 0f);
        if (transform.position.x > 12f || transform.position.x < -12f)
        {
            if (direction == CloudDirection.Left)
                transform.position = new Vector3(12f, transform.position.y, transform.position.z);
            else if (direction == CloudDirection.Right)
                transform.position = new Vector3(-12f, transform.position.y, transform.position.z);
        }
    }
}
