using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] public static int NextGame = 0;

   public void LoadSceneGame1()
    {
        SceneManager.LoadScene(1);


    }
    public void LoadSceneGame2()
    {
        if (NextGame >= 1)
        {
            SceneManager.LoadScene(2);

        }
    }
    public void LoadSceneGame3()
    {
        if (NextGame >= 2)
        {
            SceneManager.LoadScene(3);

        }


    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

   
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
