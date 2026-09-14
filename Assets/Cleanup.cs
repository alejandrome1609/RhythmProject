using UnityEngine;

public class Cleanup : MonoBehaviour
{
    //Here, the idea was to make a zone that would destroy the notes if a player missed rather than them staying in the scene and maybe crashing the game, or burning my pc like what almost happened to me. Coding is similar to our hitzone as they act kind of the same, just without the condition of pressing space.
    //To do this, I made a private variable referencing the a note component, private because only this will need it likewise in the hitzone.
    private Note incomingNote;
    //I then gave this zone a trigger, so that then when a notes collider touches it, it can detect its a note by getting a reference to the component, and if it doesnt come out with null
    //It pretty much deletes the whole note game object that incomingNote was referencing.
    //I also added gameManger.NoteRemoved here as well to tell game manager that a note was just removed if it was destroyed in the clean up zone, beacuse this also has the ability to remove notes.
    public void OnTriggerEnter2D(Collider2D other)
    {
        incomingNote = other.gameObject.GetComponent<Note>();
        if (incomingNote != null)
        {
            gameManager.NoteRemoved();
            Destroy(incomingNote.gameObject);
        }
    }
    //And that's possible because of this, as this allows us to reference GameManager where that function lies and also allows the cleanup zone to notify gamemanager that a note was removed. We had to also assigned in the inspector.
    public GameManager gameManager;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
