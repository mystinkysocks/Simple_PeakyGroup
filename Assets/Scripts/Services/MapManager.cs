using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour, IService
{
    [Header("Base")]
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject map;
    [Header("Grid")]
    [SerializeField] private GridLayoutGroup gridComponent;
    [SerializeField] private Transform container;
    [SerializeField] private MapCellItem prefab;

    private List<MapCellItem> cells = new List<MapCellItem>();
    private void Start()
    {
        ServiceLocator.Instance.Register(this);
    }
    public IEnumerator Init()
    {
        OnCloseButton();
        closeButton.onClick.AddListener(OnCloseButton);
        yield return null;
    }
    public void Show()
    {
        map.SetActive(true);
        Build();
    }
    private void OnCloseButton()
    {
        map.SetActive(false);
    }

    private void Build()
    {
        for (int i = 0; i < cells.Count; i++)
            Destroy(cells[i].gameObject);
        
        cells.Clear();

        if (!ServiceLocator.Instance.TryGet(out GridBuilder service))
            return;

        gridComponent.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridComponent.constraintCount = service.Grid.GetLength(0);

        for(int x = service.Grid.GetLength(1) - 1; x >= 0; x--)
        {
            for(int y = 0; y < service.Grid.GetLength(0); y++)
            {
                var cell = Instantiate(prefab, container);
                cell.UpdateText(service.Grid[y, x]);
                cells.Add(cell);
            }
        }
    }
}
