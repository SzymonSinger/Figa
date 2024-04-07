using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public AudioSource audio;
    public AudioSource mainAudio;

    private void OnEnable()
    {
        mainAudio.enabled = false;
        audio.Play();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
