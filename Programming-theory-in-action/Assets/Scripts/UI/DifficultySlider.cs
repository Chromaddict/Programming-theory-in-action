using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultySlider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI difficultyText;
    [SerializeField] Slider slider;
    void Start()
    {
        slider.value = GameManager.Instance.difficulty;
    }

    void Update()
    {
        GameManager.Instance.difficulty = slider.value;
        
        if (GameManager.Instance.difficulty <= 1.5)
        {
            difficultyText.text = "Difficulty: Easy";
            return;
        }
        if (GameManager.Instance.difficulty <= 2.75)
        {
            difficultyText.text = "Difficulty: Medium";
            return;
        }
        difficultyText.text = "Difficulty: Hard";
        
        
    }
}
