using UnityEngine;

public class Note : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D noteBody;
    void Start()
    {
        noteBody.linearVelocity = new Vector2(0, -3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
