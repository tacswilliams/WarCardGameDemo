using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Variables for card images
    public SpriteRenderer leftCard;
    public SpriteRenderer rightCard;

    // Variables for UI text
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI cpuScoreText;

    // Variables to store score
    private int playerScore = 0;
    private int cpuScore = 0;

    // Start: Runs once at the beginning while the scene is loading
    void Start()
    {
        // Resets scores to 0
        playerScore = 0;
        cpuScore = 0;

        // Resets UI text to match scores
        playerScoreText.text = "Player: " + playerScore;
        cpuScoreText.text = "CPU: " + cpuScore;
    }

    //OnRestartButtonPressed: Reloads the entire scene based on scene index
    public void OnRestartButtonPressed()
    {
        // Since we only have 1 scene, it is at build index 0
        SceneManager.LoadScene(0);
    }

    // OnDealButtonPressed: Generates a new card and calls to determine the winnner
    public void OnDealButtonPressed()
    {
        // Generates a random integer [2,15)
        int left = Random.Range(2, 15);
        int right = Random.Range(2, 15);

        // Uses the number generated to load the correct card
        leftCard.sprite = Resources.Load<Sprite>("card" + left);
        rightCard.sprite = Resources.Load<Sprite>("card" + right);

        // Determines the winner based on generated numbers
        DetermineWinner(left, right);
    }

    // Determine Winner: compares two integers and makes the larger one the winner
    // Parameters: int left, int right
    public void DetermineWinner(int left, int right)
    {
        if(left > right)
        {
            // Player has won. Increase player socre and set the UI text 
            playerScore += 1;
            playerScoreText.text = "Player: " + playerScore;
        }
        else if(right > left)
        {
            // CPU has won. Increase cpu score and set the UI text
            cpuScore += 1;
            cpuScoreText.text = "CPU: " + cpuScore;
        }
    }
}
