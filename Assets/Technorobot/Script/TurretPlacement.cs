using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class TurretPlacement : MonoBehaviour
{
    [System.Serializable]
    public class TurretData
    {
        public string name; // Назва турелі (наприклад, "Ферма грошей")
        public GameObject prefab; // Префаб турелі
        public int cost; // Вартість турелі
        public Vector2Int size; // Розмір турелі в клітинках (наприклад, 2x2)
        public Button uiButton; // Кнопка в UI для вибору турелі
    }

    [SerializeField] private TurretData[] turrets; // Масив доступних турелей
    [SerializeField] private GameObject[] gridCells; // Масив клітинок карти (16x16 = 256)
    [SerializeField] private Material highlightMaterial; // Матеріал для підсвічування
    [SerializeField] private Material defaultMaterial; // Стандартний матеріал клітинки
    [SerializeField] private LayerMask gridLayer; // Шар для клітинок карти
    [SerializeField] private TextMeshProUGUI moneyText; // TextMeshPro для відображення грошей
    [SerializeField] private int startingMoney = 1000; // Початкова кількість грошей (налаштовується в Inspector)

    private TurretData selectedTurret; // Обрана турель
    private int playerMoney; // Поточна кількість грошей
    private List<GameObject> highlightedCells = new List<GameObject>(); // Список підсвічених клітинок
    private Dictionary<Vector2Int, GameObject> occupiedCells = new Dictionary<Vector2Int, GameObject>(); // Зайняті клітинки

    public delegate void OnMoneyChanged(int newAmount);
    public event OnMoneyChanged MoneyChanged; // Подія зміни грошей

    private void Start()
    {
        // Ініціалізація кількості грошей
        playerMoney = startingMoney;

        // Ініціалізація UI кнопок для вибору турелей
        foreach (var turret in turrets)
        {
            turret.uiButton.onClick.AddListener(() => SelectTurret(turret));
        }

        // Оновлення UI грошей
        UpdateMoneyUI();
    }

    private void Update()
    {
        // Якщо обрана турель, обробляємо підсвічування та розміщення
        if (selectedTurret != null)
        {
            HandleHighlight();
            HandlePlacement();
        }
    }

    private void SelectTurret(TurretData turret)
    {
        // Вибір турелі
        selectedTurret = turret;
        ClearHighlight(); // Очистити попереднє підсвічування
    }

    private void HandleHighlight()
    {
        // Очищаємо попереднє підсвічування
        ClearHighlight();

        // Отримуємо позицію миші
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, gridLayer))
        {
            GameObject hitCell = hit.collider.gameObject;
            Vector2Int gridPos = GetGridPosition(hitCell);

            // Перевіряємо, чи можна розмістити турель
            if (CanPlaceTurret(gridPos, selectedTurret.size))
            {
                HighlightCells(gridPos, selectedTurret.size);
            }
        }
    }

    private void HandlePlacement()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, gridLayer))
            {
                GameObject hitCell = hit.collider.gameObject;
                Vector2Int gridPos = GetGridPosition(hitCell);

                // Спроба розмістити турель
                if (CanPlaceTurret(gridPos, selectedTurret.size) && playerMoney >= selectedTurret.cost)
                {
                    PlaceTurret(gridPos);
                }
            }
        }
    }

    private Vector2Int GetGridPosition(GameObject cell)
    {
        // Отримуємо індекс клітинки в сітці 16x16
        int index = System.Array.IndexOf(gridCells, cell);
        return new Vector2Int(index % 16, index / 16);
    }

    private bool CanPlaceTurret(Vector2Int gridPos, Vector2Int size)
    {
        // Перевіряємо, чи достатньо грошей
        if (playerMoney < selectedTurret.cost)
        {
            return false;
        }

        // Перевіряємо, чи всі клітинки вільні та в межах карти
        for (int x = gridPos.x; x < gridPos.x + size.x; x++)
        {
            for (int y = gridPos.y; y < gridPos.y + size.y; y++)
            {
                if (x >= 16 || y >= 16 || x < 0 || y < 0 || occupiedCells.ContainsKey(new Vector2Int(x, y)))
                {
                    return false;
                }
            }
        }
        return true;
    }

    private void HighlightCells(Vector2Int gridPos, Vector2Int size)
    {
        // Підсвічуємо клітинки відповідно до розміру турелі
        for (int x = gridPos.x; x < gridPos.x + size.x; x++)
        {
            for (int y = gridPos.y; y < gridPos.y + size.y; y++)
            {
                if (x < 16 && y < 16 && x >= 0 && y >= 0)
                {
                    int index = y * 16 + x;
                    GameObject cell = gridCells[index];
                    cell.GetComponent<Renderer>().material = highlightMaterial;
                    highlightedCells.Add(cell);
                }
            }
        }
    }

    private void ClearHighlight()
    {
        // Очищаємо підсвічування
        foreach (var cell in highlightedCells)
        {
            cell.GetComponent<Renderer>().material = defaultMaterial;
        }
        highlightedCells.Clear();
    }

    private void PlaceTurret(Vector2Int gridPos)
    {
        // Розміщуємо турель
        Vector3 position = gridCells[gridPos.y * 16 + gridPos.x].transform.position;
        // Коригуємо позицію для турелей розміром більше 1x1 (центруємо турель)
        position += new Vector3((selectedTurret.size.x - 1) * 0.5f, 0, (selectedTurret.size.y - 1) * 0.5f);
        GameObject turret = Instantiate(selectedTurret.prefab, position, Quaternion.identity);

        // Займаємо клітинки
        for (int x = gridPos.x; x < gridPos.x + selectedTurret.size.x; x++)
        {
            for (int y = gridPos.y; y < gridPos.y + selectedTurret.size.y; y++)
            {
                occupiedCells.Add(new Vector2Int(x, y), turret);
            }
        }

        // Віднімаємо гроші
        playerMoney -= selectedTurret.cost;
        MoneyChanged?.Invoke(playerMoney);
        UpdateMoneyUI();

        // Скидаємо вибір турелі
        selectedTurret = null;
        ClearHighlight();
    }

    private void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"Money: {playerMoney}";
        }
    }
}