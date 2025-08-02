using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

   public void LoadSceneGame(int index)
    {
        SceneManager.LoadScene(index);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

   
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
