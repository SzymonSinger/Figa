using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatCounter : MonoBehaviour
{
    public TextMeshProUGUI _combo;
    public TextMeshProUGUI _score;
    public GameObject[] _lifes;

    public int hited = 0;

    public int missed = 0;
    public int combo = 0;
    public int perfect = 0;
    public int good = 0;
    private int score = 0;
    private int health = 5;

    private int maxHealth = 5;
    // Start is called before the first frame update
    void Start()
    {
        _combo = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            ReloadLevel();
        }
        
        for (int i = health; i > 0; i--)
        {
            _lifes[i].SetActive(true);
        }

        for (int i = health+1; i<= maxHealth; i++)
        {
            _lifes[i].SetActive(false);
        }

        _combo.text = $"Combo:X{combo.ToString()}";
        _score.text = $"Score:{score.ToString()}";
    }

    public void ScoreCalculator(int points)
    {
        score += points * combo;
    }

    public void RemoveHealth()
    {
        health--;
    }

    public void AddHealth()
    {
        health++;
    }
    
    void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
