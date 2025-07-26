using UnityEngine;

public class owerShoot : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shootSound;  // ���� ��������
    public AudioClip hitSound;    // ���� ��������� 

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


