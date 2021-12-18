using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScoreWorkAround : MonoBehaviour
{
    [SerializeField]
    public Text _scoreText;
    GameManager Game_Manager;
    // Start is called before the first frame update
    void Start()
    {
        Game_Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _scoreText.text = "Score " + Game_Manager.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
