using UnityEngine;

public class TurretSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shootSound;  // звук выстрела
    public AudioClip hitSound;    // звук попадания 

    void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        audioSource.PlayOneShot(shootSound);
    }

    public void HitTarget()
    {
        if (hitSound != null)
            audioSource.PlayOneShot(hitSound);
    }
}


