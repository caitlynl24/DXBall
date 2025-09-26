using UnityEngine;
//Use this if you're using TextMeshPro
using TMPro;
using UnityEngine.SceneManagement;

public class scoreScript : MonoBehaviour
{
    public GameObject ball;
    public GameObject paddlecontroller;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    int score = 0;

    public void addScore(int input)
    {
        if(input == 1)
        {
            score = score + input;
            scoreText.text = score.ToString() + " Points";
            //for testing purposes
            if(score == 6)
            {
                winText.text = "You Win!";
                ball.SetActive(false);
                paddlecontroller.SetActive(false);
                SceneManager.LoadScene("Level2");
            }
        }
        else if(input == 0)
        {
            winText.text = "Game Over";
        }
    }
}