using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class achivement2 : MonoBehaviour
{
    public Image achievementButton;
    void Start()
    {
        LoadColor();
        Invoke(nameof(ChangeColor), 5f);
    }

    void ChangeColor()
    {
        Color newColor = Color.green;
        achievementButton.color = newColor;
        PlayerPrefs.SetFloat("R", newColor.r);
        PlayerPrefs.SetFloat("G", newColor.g);
        PlayerPrefs.SetFloat("B", newColor.b);
        PlayerPrefs.Save();
    }

    void LoadColor()
    {
        float r = PlayerPrefs.GetFloat("R", 1f);
        float g = PlayerPrefs.GetFloat("G", 1f);
        float b = PlayerPrefs.GetFloat("B", 1f);
        achievementButton.color = new Color(r, g, b);
    }



}

        
        
            
            

