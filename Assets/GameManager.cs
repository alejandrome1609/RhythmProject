using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text scoreText;
    public GameObject notePrefab;
    public Transform noteSpawnPoint;
    private int score = 0;
    public void AddPoint()
    {
        score = score + 1;
        scoreText.text = "Score: " + score.ToString();
    }

    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
