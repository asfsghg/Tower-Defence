using UnityEngine;
using UnityEngine.UI;

public class BaseHealt : MonoBehaviour
{
    public int baseHealth = 1;
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
            Destroy(gameObject);
        }
    }
}



