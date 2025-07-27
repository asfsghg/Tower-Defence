using UnityEngine;
using UnityEngine.UI;

public class BaseHealt : MonoBehaviour
{
    public int baseHealth = 1000;
    public Slider healthSlider;
    private void Start()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = baseHealth;
            healthSlider.value = baseHealth; 
        }
    }
    public void TakeDamage(int damage)
    {
        baseHealth -= damage;
        if (healthSlider != null)
            healthSlider.value = baseHealth;

        if (baseHealth <= 0)
        {
        }
    }
}



