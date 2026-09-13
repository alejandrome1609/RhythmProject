using UnityEngine.InputSystem;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Note incomingNote;
    public void OnTriggerEnter2D(Collider2D other)
    {
        incomingNote = other.gameObject.GetComponent<Note>();
        if (incomingNote != null)
        {
            Debug.Log("Note Entered Hit Zone!");
        }

     
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

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && incomingNote != null)
        {
            Destroy(incomingNote.gameObject);
            incomingNote = null;
            gameManager.AddPoint();
        }
    }
}
