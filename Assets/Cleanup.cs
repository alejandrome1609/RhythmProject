using UnityEngine;

public class Cleanup : MonoBehaviour
{
    
    private Note incomingNote;
    public void OnTriggerEnter2D(Collider2D other)
    {
        incomingNote = other.gameObject.GetComponent<Note>();
        if (incomingNote != null)
        {
            gameManager.NoteRemoved();
            Destroy(incomingNote.gameObject);
        }
    }
    public GameManager gameManager;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
