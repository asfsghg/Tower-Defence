using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyController : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI moneyText;
    [SerializeField] public int moneyAmount;

    

    void Update()
    {
        moneyText.text = moneyAmount.ToString();
    }

}
