using UnityEngine;

public class Note : MonoBehaviour
{
    //Here I first made a public variable in which would allow it to reference the RigidBody of our Note gameobject. I then assigned to in the inspector of course.
    public Rigidbody2D noteBody;
    //Now here in void start, I gave this new public variable a velocity of -6, meaning the notes would go downwards
    //At 6 units per second! And because I wanted these notes to go at a constant speed, I set gravity to 0 and damping at 0 as well.
    //Was not nessecary to put it in Update because physics literally handle the rest. That being RigidBody2D which make it keep moving!
    void Start()
    {
        noteBody.linearVelocity = new Vector2(0, -6);
    }

    
    void Update()
    {
        
    }
}
