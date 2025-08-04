using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClic : MonoBehaviour
{
   [SerializeField] public AudioSource soundClic;

    public void PlayThisSoung()
    {
        soundClic.Play();
    }
}
