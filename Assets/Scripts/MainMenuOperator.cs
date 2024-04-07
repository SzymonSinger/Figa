using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOperator : MonoBehaviour
{
    public GameObject levelSelect;

    public void EnterLevelSelect()
    {
        levelSelect.SetActive(true);
    }

    public void ExitLevelSelect()
    {
        levelSelect.SetActive(false);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(2);
    }
    
    public void LoadSecondLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadThirdLevel()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
