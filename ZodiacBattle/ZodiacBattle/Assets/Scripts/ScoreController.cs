using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private int score = 0;
    private int highScore; 
    public Text scoreText;
    public Text currentHighScore;

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {

            this.highScore = PlayerPrefs.GetInt("HighScore");
            Debug.Log(highScore);
            PlayerPrefs.SetInt("HighScore", this.score);
            currentHighScore.text = "High Score: " + this.highScore.ToString();


        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.score++;
            scoreText.text = "Score: " + this.score.ToString();
        }
            
    }
}
