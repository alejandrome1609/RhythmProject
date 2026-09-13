using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text finalScoreText;
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void Start()
    {
        finalScoreText.text = "Score: " + GameManager.finalScore.ToString();
    }

    
    void Update()
    {
        
    }
}
