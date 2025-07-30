using UnityEngine;

public class PlacePrefab : MonoBehaviour
{
    public GameObject prefabToPlace; 
    public float placeOffset = 0.1f;  

    void Update()
    {
      
        if (Input.GetKey(KeyCode.Q))
        {
            PlaceObjectUnderMouse();
        }
    }

    void PlaceObjectUnderMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit))
        {
            
            Vector3 spawnPosition = hit.point + hit.normal * placeOffset;
            Instantiate(prefabToPlace, spawnPosition, Quaternion.identity);
        }
    }
}
