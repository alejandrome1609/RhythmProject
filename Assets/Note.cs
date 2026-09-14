using UnityEngine;

public class Note : MonoBehaviour
{
    //The idea here was to get the notes to move vertically downwards.
    //To do this, here I first made a public variable in which would allow it to reference the RigidBody2d component which I assigned through the inspector
    public Rigidbody2D noteBody;
    //Now here in void start, I gave this new public variable a velocity of -6, meaning it tells the RigidBody to move the notes downwards
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
