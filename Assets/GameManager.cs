using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public GameObject notePrefab;
    public Transform noteSpawnPoint;
    private int score = 0;
    private float spawnTimer = 1f;
    private float roundTimer = 30f;
    private bool spawningActive = true;
    private int notesRemaining = 0;
    public static int finalScore;
    public void AddPoint()
    {
        score = score + 1;
        scoreText.text = "Score: " + score.ToString();
    }
    public void NoteRemoved()
    {
        notesRemaining = notesRemaining - 1;
    }
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    
    void Update()
    {
        if (roundTimer > 0)
        {
            roundTimer = roundTimer - Time.deltaTime;
            if (roundTimer <= 0)
            {
                spawningActive = false;
            }
            if (spawningActive == true)
            {
                timerText.text = "Time: " + roundTimer.ToString("F0");
            }
            else
            {
                timerText.text = "Finish!";
            }
        }
        spawnTimer = spawnTimer - Time.deltaTime;
        if (spawnTimer <= 0 && spawningActive == true)
        {
            Instantiate(notePrefab, noteSpawnPoint.position, Quaternion.identity);
            spawnTimer = Random.Range(0.2f,1.3f);
            notesRemaining = notesRemaining + 1;
        }
        if (spawningActive == false && notesRemaining == 0)
        {
            finalScore = score;
            SceneManager.LoadScene("GameOver");
        }
    }
}
