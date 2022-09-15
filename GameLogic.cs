using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Update(){
        scoreText.text = "Score: " + score;
    }
    
    
    public void GetScore(){
        score = score + 1;
    }

    public void GetScoreKillEnemy(){
        score = score + 5;
    }
}