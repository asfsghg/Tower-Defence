using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int scene;
    public void changeScene()
    {
        SceneManager.LoadScene(scene);
    }

   public void LoadSceneGame(int index)
    {
        SceneManager.LoadScene(index);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
