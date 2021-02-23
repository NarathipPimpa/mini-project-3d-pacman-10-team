using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int currentScore;
    

    public Text scoreText;
    public Text gemText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = "Score: " + currentScore;
    }

    public void AddGem()
    {
        gemText.text = "Gems Collected: " + FindObjectOfType<EndGameTrigger>().gems;

    }


}
