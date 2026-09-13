using UnityEngine.InputSystem;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    
    private Note incomingNote;
    public void OnTriggerEnter2D(Collider2D other)
    {
        incomingNote = other.gameObject.GetComponent<Note>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Note departingNote = other.gameObject.GetComponent<Note>();
        if (departingNote == incomingNote)
        {
            incomingNote = null;
        }



    }

    public GameManager gameManager;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && incomingNote != null)
        {
            gameManager.NoteRemoved();
            Destroy(incomingNote.gameObject);
            incomingNote = null;
            gameManager.AddPoint();
        }
    }
}
