using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //This is where most of the heavy lifting happens so im gonna try to explain quickly. These two are pretty much references assigned in the inspector to update the onscreen text as we know.
    public TMP_Text scoreText;
    public TMP_Text timerText;
    //Here I actually made the Notes a prefab so we can keep using them, this is just to tell the code the prefab it should copy. And below is another interesting variable where it will actually allow us to position our notes to spawn from there.
    public GameObject notePrefab;
    public Transform noteSpawnPoint;
    //Here, this is just pretty much to tell the engine to start at 0 points, and to wait after one second to spawn a note.
    private int score = 0;
    private float spawnTimer = 1f;
    //This allows notes to spawn for 30 seconds, why did I add a boolean variable? Because it will then help tell the game when notes should stop spawning, which should be after the roundtimer is over or at 0 in this case.
    private float roundTimer = 30f;
    private bool spawningActive = true;
    //I also decided to add this so that we can track how many notes are active in the game, so that when the round ends, it doesnt end before all notes are hit.
    private int notesRemaining = 0;
    //This was nessecary to add after deciding to add the Final Score to the game over screen. Learned that it allows to transfer values between scenes without changing or reseting them since it belongs to the class.
    public static int finalScore;
    //Hitzone as we remember will call this upon a sucessfull hit. GameManager will then update the score and display it.
    public void AddPoint()
    {
        score = score + 1;
        scoreText.text = "Score: " + score.ToString();
    }
    //As we remember, Hitzone and Cleanup call this when they remove a note! Since both hitting the note and missing them decrease the count as they both remove notes.
    public void NoteRemoved()
    {
        notesRemaining = notesRemaining - 1;
    }
    //Decided to add this to display the score when the scene begins.
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    
    void Update()
    {
        //This pretty much allows time to count down while theres still time left, subtracting time since the last frame.
        if (roundTimer > 0)
        {
            roundTimer = roundTimer - Time.deltaTime;
            //Here, this allows for new notes to stop spawning when time reaches or passes 0. But like we said, existing notes can still be hit!
            if (roundTimer <= 0)
            {
                spawningActive = false;
            }
            //Here was a little tricky because at first I was seeing weird numbers. But I managed to fix it with F0, which displays the time rounded to 0 decimal places!
            //Meaning that while notes are spawning, time will show in seconds, dropping by one second as time goes by!
            if (spawningActive == true)
            {
                timerText.text = "Time: " + roundTimer.ToString("F0");
            }
            else
            {
                //This runs if there's no more notes spawning, pretty much decided to add it in case players decided to give up if they saw the timer finishing, not knowing they can still hit the remaining notes!
                timerText.text = "Finish!";
            }
        }
        //just counts down the delay before the next note.
        spawnTimer = spawnTimer - Time.deltaTime;
        //Notes ONLY spawn if both the spawn timer is less than or equal to 0, and if notes are still allowed to spawn. And of course increase the count of notes remaining when a new one spawns.
        if (spawnTimer <= 0 && spawningActive == true)
        {
            Instantiate(notePrefab, noteSpawnPoint.position, Quaternion.identity);
            //This actually allows notes to spawn in random intervals to make the game a little harder.
            spawnTimer = Random.Range(0.2f,1.3f);
            notesRemaining = notesRemaining + 1;
        }
        //And if spanwing is no longer allowed and notes remaining in the field are 0, then switch the scene while saving the score before doing so.
        if (spawningActive == false && notesRemaining == 0)
        {
            finalScore = score;
            SceneManager.LoadScene("GameOver");
        }
    }
}
