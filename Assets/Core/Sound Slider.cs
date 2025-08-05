using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
  [SerializeField] Slider slider;
    void Start()
    {
        if (!PlayerPrefs.HasKey("SoundSlider"))
        {
            PlayerPrefs.SetInt("SoundSlider", 1);
            
        }
    }

    public void ChangeSound()
    {
        AudioListener.volume = slider.value;
    }
    
    

}
