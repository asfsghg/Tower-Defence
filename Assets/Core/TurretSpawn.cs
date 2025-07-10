using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Video;

public class BuildingPlacer : MonoBehaviour
{
    public GameObject buildingPrefab; // префаб турелі
    private GameObject buildingInstance; // посилання на створений префаб
    public Vector3 mouseWorldPosition; // позиція миші
    private float time = 2f; //затримка між спавном

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Build();
        }
    }

    private void Build()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Building"))
            {
                mouseWorldPosition = hit.point;
                buildingInstance = Instantiate(buildingPrefab, mouseWorldPosition, Quaternion.identity);
                hit.collider.tag = "Untagged";
            }
        }
    }
}