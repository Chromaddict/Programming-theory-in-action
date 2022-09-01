using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    GridManager gridManager;
    [SerializeField] TextMeshProUGUI scoreText;
    float score;
    int oldScore;
    void Start()
    {
        gridManager = GameObject.FindObjectOfType<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        score = gridManager.CleanTiles * GameManager.Instance.difficulty;
        if (score != oldScore)
        {
            scoreText.text = "Score:" + (int)score;
            oldScore = (int)score;
            GameManager.Instance.score = (int)score;
        }
    }
}
