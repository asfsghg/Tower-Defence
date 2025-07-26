using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClic : MonoBehaviour
{
    public AudioSource soundClic;

    public void PlayThisSoung()
    {
        soundClic.Play();
    }
}
