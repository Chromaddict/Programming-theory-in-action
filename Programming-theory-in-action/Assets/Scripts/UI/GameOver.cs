using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    [SerializeField] TextMeshProUGUI highScore;
    
    
    void Start()
    {
        highScore.text = "High Score:" + GameManager.Instance.highScore + " Time:" + GameManager.Instance.timeElapsedHS.ToString("F2");
        finalScore.text = "Final Score:\n" + GameManager.Instance.score + "\nTime:\n"+GameManager.Instance.timeElapsed.ToString("F2");
        
    }
}
