using System;
using UnityEngine;
using System.Collections.Generic;

public class BuildingPlacer : MonoBehaviour
{
   public GameObject buildingPrefab; //префаб турелі
   private GameObject buildingInstance; // позиція турелі через рейкаст
   public Vector3 mouseWorldPosition; // миша

   void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
   
         if (Physics.Raycast(ray, out RaycastHit hit))
         {
            if (hit.collider.tag == "Building")
            {
               mouseWorldPosition = hit.point;
               buildingInstance = Instantiate(buildingPrefab.gameObject, mouseWorldPosition, Quaternion.identity);
               buildingInstance.transform.parent = transform;
               hit.collider.tag = "Untagged";
               
            }
         }
      }
      
   }
   
}