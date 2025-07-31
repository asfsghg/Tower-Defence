using System;


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    private GameObject _currentTurret;
    private MoneyController _moneyController;
    private bool _IsBuilding;
    [SerializeField] private ShopTurret[] _ShopTurrets;

    private void Awake()
    {
        _moneyController = FindObjectOfType<MoneyController>();
    }

    public void BuyButtonTurret(int index)
    {
        if (_moneyController.moneyAmount >= _ShopTurrets[index].price)
        {
            _moneyController.moneyAmount -= _ShopTurrets[index].price;
            _currentTurret = _ShopTurrets[index].turret;
        }
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
               
            SpawnBuilding();
        }
    }


    public void SpawnBuilding()
    {
        if (_IsBuilding == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out BuildingPlacer buildingPlacer) && buildingPlacer.IsBuilding == false)
                {
                    if (_currentTurret != null)
                    {
                        Vector3 spawnPosition = hit.point;
                        spawnPosition.y = 2.36f; 
                        Instantiate(_currentTurret, spawnPosition, Quaternion.identity);
                        
                        _currentTurret = null;
                    }
                }
            }
        }
    }

}

[System.Serializable]
public class ShopTurret
{
    public GameObject turret;
    public int price;
}