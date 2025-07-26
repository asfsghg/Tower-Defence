using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySpend : MonoBehaviour
{

    [SerializeField] private GameObject buildingPrefab; // префаб турелі
    private GameObject buildingInstance; // посилання на створений префаб
    public Vector3 mouseWorldPosition; // позиція миші
    private bool _IsBuilding;
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
        else
        {
            _IsBuilding = false;
        }
    }

    public void SpawnBuilding()
    {
        if (_IsBuilding == true)
        {
            FindObjectOfType<MoneyController>().moneyAmount -= Price;  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Building"))
                {
                    mouseWorldPosition = hit.point;
                    mouseWorldPosition.y = 2.36f;
                    buildingInstance = Instantiate(buildingPrefab, mouseWorldPosition, Quaternion.identity);

                    hit.collider.tag = "Untagged";
                    
                    
                }
            }
        }
    }
}
