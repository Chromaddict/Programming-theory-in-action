using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeElapsed;
    [SerializeField] TextMeshProUGUI timerText;
    public float TimeElapsed { get {return timeElapsed;} }
    void Start()
    {
        
        timerText.text = "Time:0.00";
    }

    
    void Update()
    {
        timeElapsed += Time.deltaTime;
        timerText.text = "Time:"+ timeElapsed.ToString("F2");
    }
}
