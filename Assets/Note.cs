using UnityEngine;

public class Note : MonoBehaviour
{
    
    public Rigidbody2D noteBody;
    void Start()
    {
        noteBody.linearVelocity = new Vector2(0, -6);
    }

    
    void Update()
    {
        
    }
}
