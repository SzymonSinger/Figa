using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEnter : MonoBehaviour
{
    private void Update()
    {
        SceneManager.LoadScene(1);
    }
}
