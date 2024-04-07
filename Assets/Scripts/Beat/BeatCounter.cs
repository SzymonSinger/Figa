using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeatCounter : MonoBehaviour
{
    public TextMeshProUGUI _combo;
    public TextMeshProUGUI _score;
    public ParticleSystem particle;

    public int hited = 0;

    public int missed = 0;
    public int combo = 0;
    public int perfect = 0;
    public int good = 0;
    private int score = 0;
    private int health = 5;
    private int maxHealth = 5;

    public GameObject[] _lifes;
    
    // Update is called once per frame
    void Update()
    {
        _combo.text = $"Combo:X{combo.ToString()}";
        _score.text = $"Score:{score.ToString()}";
        HealthUpdater();
    }


    void HealthUpdater()
    {
        switch (health)
        {
            case 0:
                ReloadLevel();
                break;
            case 1:
                _lifes[0].SetActive(true);
                _lifes[1].SetActive(false);
                _lifes[2].SetActive(false);
                _lifes[3].SetActive(false);
                _lifes[4].SetActive(false);
                break;
            case 2:
                _lifes[0].SetActive(true);
                _lifes[1].SetActive(true);
                _lifes[2].SetActive(false);
                _lifes[3].SetActive(false);
                _lifes[4].SetActive(false);
                break;
            case 3:
                _lifes[0].SetActive(true);
                _lifes[1].SetActive(true);
                _lifes[2].SetActive(true);
                _lifes[3].SetActive(false);
                _lifes[4].SetActive(false);
                break;
            case 4:
                _lifes[0].SetActive(true);
                _lifes[1].SetActive(true);
                _lifes[2].SetActive(true);
                _lifes[3].SetActive(true);
                _lifes[4].SetActive(false);
                break;
            case 5:
                _lifes[0].SetActive(true);
                _lifes[1].SetActive(true);
                _lifes[2].SetActive(true);
                _lifes[3].SetActive(true);
                _lifes[4].SetActive(true);
                break;
            default:
                break;
        }
    }
    public void ScoreCalculator(int point)
    {
        score += point * combo;
    }

    public void PerfectStrike()
    {
        particle.Play();
    }

    public void AddHealth()
    {
        health++;
    }

    public void RemoveHealth()
    {
        health--;
    }
    void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
