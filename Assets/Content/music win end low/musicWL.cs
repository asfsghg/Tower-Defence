using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicWL : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip victoryClip;
    public AudioClip defeatClip;

  
    public void PlayVictoryMusic()
    {
        audioSource.clip = victoryClip;
        audioSource.Play();
    }

   
    public void PlayDefeatMusic()
    {
        audioSource.clip = defeatClip;
        audioSource.Play();
    }
}
