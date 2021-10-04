using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score " + score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addScore(int points)
    {
        //Debug.Log(score);
        score += points;
        _scoreText.text = "Score " + score;
    }

    public void clearScore()
    {
        score = 0;
        _scoreText.text = "Score " + score;
    }
    /*
    public void updateScore()
    {
        _scoreText.text = "Score " + score;
    }
    */
}
