using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    private card _cardSO;

    public card cardSO
    {
        get => _cardSO;
        set { _cardSO = value;}
    }
    private GameObject _draggingBuilding;
    private Building _building;

    private Vector2 _gridSize = new Vector2Int(15, 10);
    private bool _isAvailableToBuild;

    private Building[,] _grid;

    private void Awake()
    {
       // _grid = new Building[_gridSize.x, _gridSize.y];
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (_draggingBuilding == null)
        {

            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float pos))
            {
                Vector3 worldPosition = ray.GetPoint(pos);

                int x = Mathf.RoundToInt(worldPosition.x);
                int z = Mathf.RoundToInt(worldPosition.z);

                _draggingBuilding.transform.position = new Vector3(x, 0, z);

               // if (x < 0 || x > _gridSize.x - _draggingBuilding.x)
                 //   _isAvailableToBuild = false;

                if ((x % 2 == 1) || (z % 2 == 1)) _isAvailableToBuild = false;
                _draggingBuilding.transform.position = new Vector3(x,0, z);

            }
        }
        //throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _draggingBuilding = Instantiate(_cardSO.prefab,Vector3.zero,Quaternion.identity);
        _building = _building.GetComponent<Building>();

        var groundPlane = new Plane(Vector3.up,Vector3.zero );
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float pos ))
        {
            Vector3 worldPosition = ray.GetPoint(pos);

            int x = Mathf.RoundToInt(worldPosition.x);
            int z = Mathf.RoundToInt(worldPosition.z);

            _draggingBuilding.transform.position = new Vector3(x,0,z);
        }
        //throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!_isAvailableToBuild)
            Destroy(_draggingBuilding);
        else
        {
            _grid[(int)_draggingBuilding.transform.position.x, (int)_draggingBuilding.transform.position.z] = _building;


        }
       // throw new System.NotImplementedException();
    }
    private bool IsPlaceTaken(int x, int y)
    {
        if (_grid[x,y] != null)
            return true;
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
