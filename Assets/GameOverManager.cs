using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    //Here, I also decided to add a gamemanager to the gameover scene aswell, where it would handle showing the score, text, etc.
    //First, I wanted to show the player their final score in the gameover scene, this was a little tricky beacuse the score was part of a different scene like we said, so we had find a way to get that info to this scene.
    //And remember, we had to use a public static variable so it stays available across all scene change which we'll use later.
    //This public variable here is just to reference the final score text which we assigned in the inpector, that way we can tweak and show it.
    public TMP_Text finalScoreText;
    //This function is for the retry button, it was actually easier than I thought because all we had to do was assign a scene change to it, and make it call it when clicked, which was all assigned on the inspector, and when clicked, it brings the scene back to the beggining, timer and score reseted and everything!
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    //Here because it only needs to run once, we pretty much grab the variable storing the final score text, and make it display the score stored from gamemanager into a string, which is the static variable I was talking about!
    void Start()
    {
        finalScoreText.text = "Score: " + GameManager.finalScore.ToString();
    }

    
    void Update()
    {
        
    }
}
