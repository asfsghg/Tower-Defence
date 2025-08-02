using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;      
    public LayerMask placeableLayer;    
    private bool isPlacing = false;

    public void StartPlacingTower()
    {
        isPlacing = true;
        
    }

    void Update()
    {
        if (!isPlacing) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, placeableLayer))
            {
                Instantiate(towerPrefab, hit.point, Quaternion.identity);
                isPlacing = false;

            }
        }
    }
}
