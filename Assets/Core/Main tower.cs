using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Maintower : MonoBehaviour
{
    [SerializeField] public int _health;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private musicWL musicPlayer;

    void Update()
    {
        if (_health <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0.1f;
            musicPlayer.PlayVictoryMusic();
        }
    }
}
