using UnityEngine.InputSystem;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    //The main idea here now is to create a zone that will allow the player to click the space key, and if they do while a note is inside this zone, score goes up and the note is destroyed.
    //To start, I made a private variable storing a reference to one Note component as we will be needing a reference to it.
    private Note incomingNote;
    //Here, we pretty much check if the whatever entered the HitZone's trigger has a Note component, and store it into our variable.
    public void OnTriggerEnter2D(Collider2D other)
    {
        incomingNote = other.gameObject.GetComponent<Note>();
    }

    //And here I decided to do the opposite, where if the departing note is the one we're remembering from the previous code, the variable will get cleared of that reference.
    //Why did I do this? Because if it didnt, it would literally allow the player to hit a note that passed through the trigger, even if it wasnt in the Hitzone, so like between the Hitzone and Cleanup zones.
    private void OnTriggerExit2D(Collider2D other)
    {
        Note departingNote = other.gameObject.GetComponent<Note>();
        if (departingNote == incomingNote)
        {
            incomingNote = null;
        }



    }

    //Here, we will need this to reference Game Manager with important functions and notify it of an important change coming up. Assigned in the inspector.
    public GameManager gameManager;

    void Start()
    {
        
    }

    //Now here, this checks in every frame that if the space key was newly pressed, and that if the variable contained a Note reference, which remember it's only possible now when it's inside the hitzone.
    //Then it will notify game manager that a note was removed and that a point should be added by calling those functions, it will also destroy the gameObject that the referenced note component belongs too, which is Note of course, and it will reset our variable back to null so we dont have a reference and the process could repeat again without any issues.
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
