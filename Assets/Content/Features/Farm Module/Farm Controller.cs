using System.Collections;
using UnityEngine;

public class FarmController : MonoBehaviour
{
    private MoneyController _moneyController;

    void Start()
    {
        _moneyController = FindObjectOfType<MoneyController>();
        StartCoroutine(AddMoneyLoop());
    }

    private IEnumerator AddMoneyLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); 
            _moneyController.moneyAmount += 20;
        }
    }
}

