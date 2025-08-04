
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class AudioController : MonoBehaviour
{
    public  AudioSource audio;
    public AudioClip clip;

    public Sprite audioOn;
    public Sprite audioOff;
    public Sprite buttonAudio;

    public Image buttonImage; 

    public Slider slider;

    void Update()
    {
        audio.volume = slider.value; 
    }
    public void OnffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = audioOn;
        }
    }
    public void PlaySound()
    {
        audio.PlayOneShot(clip);
    }
}








