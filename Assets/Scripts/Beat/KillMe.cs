using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class KillMe : MonoBehaviour
{
    public bool goodDestroy = false;
    public bool perfectDestroy = false;
    private BeatCounter counter;
    private JumpHandler jump;

    private void Awake()
    {
        jump = FindObjectOfType<JumpHandler>();
        counter = FindObjectOfType<BeatCounter>();
    }

    private void Update()
    {
        /*if (counter.missed >= 5)
        {
            ReloadLevel();
        }*/
        if (goodDestroy && !perfectDestroy)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                DontShootGood();
            }
        }
        if (perfectDestroy && !goodDestroy)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                DontShootPerfect();
            }
        }
    }

    

    public void PerfectHit()
    {
        goodDestroy = false;
        perfectDestroy = true;
        jump.canJump = true;
    }

    public void GoodHit()
    {
        goodDestroy = true;
        perfectDestroy = false;
        jump.canJump = true;
    }
    
    public void DontShootPerfect()
    {
        counter.PerfectHit();
        jump.canJump = false;
        counter.hited++;
        counter.perfect++;
        counter.combo++;
        counter.ScoreCalculator(100);
        Destroy(gameObject);
    }
    public void DontShootGood()
    {
        jump.canJump = false;
        counter.hited++;
        counter.good++;
        counter.combo++;
        counter.ScoreCalculator(50);
        Destroy(gameObject);
    }
    public void Suicide()
    {
        counter.RemoveHealth();
        jump.canJump = false;
        counter.missed++;
        counter.combo = 0;
        Destroy(gameObject);
    }
    
    void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
