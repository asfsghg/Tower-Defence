using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Maintower : MonoBehaviour
{
    [SerializeField] public int _health;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private musicWL musicPlayer;
    [SerializeField] public TextMeshProUGUI healthText;
    
    [SerializeField] public Slider textMaxHealth;

    private bool _isGameOver = false;

    private void Awake()
    {
       textMaxHealth.value = _health;
    }

    void Update()
    {
        healthText.text = _health.ToString();

        if (_health <= 0 && !_isGameOver)
        {
            _isGameOver = true;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0.1f;
            musicPlayer.PlayDefeatMusic();
        }
    }

    public void TimeScale()
    {
        Time.timeScale = 1;
        
    }
}