using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySpend3 : MonoBehaviour
{
    
    private bool _IsBuilding;
    [SerializeField] private GameObject _MoneySpendTurret;
    [SerializeField] private int Price;
    

    void Update()
    {
        if (FindObjectOfType<MoneyController>().moneyAmount >= Price)
        {
            _IsBuilding = true;

            if (Input.GetMouseButtonDown(0))
            {
                SpawnBuilding();
            }
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
                if (hit.collider.CompareTag("Building"))
                {
                    var moneyController = FindObjectOfType<MoneyController>();
                    if (moneyController.moneyAmount >= Price)
                    {

                        moneyController.moneyAmount -= Price;


                        var placer = FindObjectOfType<BuildingPlacer>();
                        placer.mouseWorldPosition = hit.point;
                        placer.mouseWorldPosition.y = 2.36f;

                        placer.buildingInstance = Instantiate(
                            _MoneySpendTurret,
                            placer.mouseWorldPosition,
                            Quaternion.identity
                        );
                        
                        hit.collider.tag = "Untagged";

                        _IsBuilding = false;
                    }
                }
            }
        }
    }

    }

