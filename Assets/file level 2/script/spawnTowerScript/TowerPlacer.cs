using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public GameObject towerPrefab;      // Префаб башни
    public LayerMask placeableLayer;    // Слой, по которому можно ставить
    private bool isPlacing = false;

    public void StartPlacingTower()
    {
        isPlacing = true;
        Debug.Log("Режим установки башни включён");
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
                Debug.Log("Башня установлена");
            }
        }
    }
}
