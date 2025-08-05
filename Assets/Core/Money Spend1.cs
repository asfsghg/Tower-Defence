using System;


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    private int _selectedTurretIndex;

    private GameObject _currentTurret;
    private MoneyController _moneyController;
    private bool _IsBuilding;
    [SerializeField] private ShopTurret[] _ShopTurrets;
    private SoundClic _SoundClic;

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
            _selectedTurretIndex = index;
            _IsBuilding = true;

        }
    }



    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            FarmSpawn();

            SpawnBuilding();
        }
    }


    public void SpawnBuilding()
    {
        if (_selectedTurretIndex != 4)
        {
            if (_IsBuilding && _currentTurret != null)
            {


                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.tag == "Building")
                    {
                        
                        Vector3 spawnPosition = hit.point;
                        spawnPosition.y = 1f;
                        Instantiate(_currentTurret, spawnPosition, Quaternion.identity);
                        _currentTurret = null;
                        _IsBuilding = false;
                        hit.collider.tag = "Untagged";
                    }



                }

            }
        }
    }

    public void FarmSpawn()
    {
        if (_selectedTurretIndex == 4)
        {
            if (_IsBuilding && _currentTurret != null)
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.tag == "Farm")
                    {
                        //_SoundClic.PlayThisSoung();
                        Vector3 spawnPosition = hit.point;
                        spawnPosition.y = 1.9f;
                        Instantiate(_currentTurret, spawnPosition, Quaternion.identity);
                        _currentTurret = null;
                        _IsBuilding = false;
                        hit.collider.tag = "Untagged";
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