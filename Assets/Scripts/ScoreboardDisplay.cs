using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreboardDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScoreText; // Assign in the inspector
    public TextMeshProUGUI currentScore;
    private AudioSource audio;
    private BeatCounter counter;

    private void Awake()
    {
        counter = FindObjectOfType<BeatCounter>();
        audio = GetComponent<AudioSource>();
        UpdateHighScoreDisplay();
    }

    private void OnEnable()
    {   
        audio.Play();
    }

    public void UpdateHighScoreDisplay()
    {
        string levelName = SceneManager.GetActiveScene().name; // Using UnityEngine.SceneManagement;
        highScoreText.text = "High Score for " + levelName + ": " + PlayerPrefsManager.LoadHighScore(levelName);
        currentScore.text = counter.score.ToString();
    }
}