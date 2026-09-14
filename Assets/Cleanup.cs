using UnityEngine;

public class Cleanup : MonoBehaviour
{
    //Here, the idea was to make a zone that would destroy the notes if a player missed rather than them staying in the scene and maybe crashing the game. Coding is similar to our hitzone.
    //To do this, I made a private variable referencing the a note component, private because only this will need it.
    private Note incomingNote;
    //I then gave this zone a trigger, so that then when a notes collider touches it, it can detect its a note by getting the component, and if it doesnt come out with null
    //It pretty much deletes the whole Note game object that incomingNote was referencing, which would be a note of course. 
    //I also added gameManger.NoteRemoved here to tell game manager that a note was just removed if it was destroyed in the clean up zone.
    public void OnTriggerEnter2D(Collider2D other)
    {
        incomingNote = other.gameObject.GetComponent<Note>();
        if (incomingNote != null)
        {
            gameManager.NoteRemoved();
            Destroy(incomingNote.gameObject);
        }
    }
    //Which is possible because of this, as this allows us to reference GameManager where that function lies and also allows Cleanup to notify GameManager that a note was removed. Assigned in the inspector.
    public GameManager gameManager;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
