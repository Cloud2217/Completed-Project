using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    void Update(){
        //transition to win scene if score requirement met
        if(score >= 40){
            SceneManager.LoadScene("Win");
        }
    }

//add to score and update ui
    public void addScore(){
        score += 1;
        scoreText.text = "Score: " + score;
    }
}
