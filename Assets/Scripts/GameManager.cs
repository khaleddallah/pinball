using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeNum;
    public GameObject winLoseText;

    bool gameOver;



    // Start is called before the first frame update
    void Start()
    {   
        gameOver = false;
        FindObjectOfType<Ball>().OnBallWin += AddScore;
        FindObjectOfType<Ball>().OnBallLose += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver){
            if(Input.GetKeyDown(KeyCode.Space)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    // public void LoseLife()
    // {
    //     lives--;
    //     lifeNum.text = "Life: " + lives;
    //     if (lives <= 0){
    //         GameOver();
    //     }
    // }

    void GameOver(){
            winLoseText.SetActive(true);
            gameOver=true;
            FindObjectOfType<Ball>().OnBallLose -= GameOver;
            FindObjectOfType<Ball>().OnBallWin -= AddScore;
    }
}
