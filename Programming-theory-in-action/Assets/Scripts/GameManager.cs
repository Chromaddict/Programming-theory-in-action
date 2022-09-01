using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public int score;
    public float difficulty = 1f;
    public int highScore;
    public float timeElapsed;
    public float timeElapsedHS;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
    public void SetDifficulty(float value)
    {
        difficulty = value;
    }
    public void StartLevel()
    {
        GameManager.Instance.score = 0;
        SceneManager.LoadScene(1);
    }
    public void CompleteLevel()
    {
        if (GameManager.Instance.difficulty <= 3.25f)
        {
            GameManager.Instance.difficulty += 0.25f;
        }
        SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        timeElapsed = GameObject.FindObjectOfType<Timer>().TimeElapsed;
        if (GameManager.Instance.score > GameManager.Instance.highScore)
        {
            GameManager.Instance.highScore = GameManager.Instance.score;
            timeElapsedHS = timeElapsed;
        }
        Save();
        SceneManager.LoadScene(2);
    }
    public void TryAgain()
    {
        Save();
        StartLevel();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public float difficulty;
        public float timeElapsedHS;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.difficulty = difficulty;
        data.timeElapsedHS = timeElapsedHS;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            difficulty = data.difficulty;
            timeElapsedHS = data.timeElapsedHS;
        }
    }
    
}
