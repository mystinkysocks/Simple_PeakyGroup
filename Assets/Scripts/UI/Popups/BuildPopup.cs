using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.UI;

public class BuildPopup : BasePopup
{
    [Header("Components")]
    [SerializeField] private BuildItem prefab;
    [SerializeField] private Transform container;

    [SerializeField] private Button buildButton;
    [SerializeField] private Button closeButton;

    private List<BuildItem> items = new();

    private BuildItem selectedItem;
    private CellComponent cellComponent;

    public void Init(CellComponent cell)
    {
        cellComponent = cell;

        if (ServiceLocator.Instance.TryGet(out BuildingManager building))
        {
            var prefabs = building.GetBuildingsPrefab();
            for (int i = 0; i < prefabs.Length; i++)
            {
                var item = Instantiate(prefab, container);
                item.Init(prefabs[i].ID, prefabs[i].ID);
                item.onClick.AddListener(OnClick);
                items.Add(item);
            }
        }
        else
        {
            Hide();
        }

        buildButton.onClick.AddListener(OnBuildButton);
        closeButton.onClick.AddListener(OnCloseButton);

        SetSelectedItem(null);
    }
    private void OnBuildButton()
    {
        if(ServiceLocator.Instance.TryGet(out BuildingManager buildingManager))
        {
            if(buildingManager.TryBuild(selectedItem.ID, cellComponent.transform, out BaseBuilding building))
            {
                cellComponent.SetBuilding(building);
            }
        }

        Hide();
    }
    private void OnCloseButton()
    {
        Hide();
    }
    private void OnClick(BuildItem item)
    {
        if (item.IsSelected)
        {
            SetSelectedItem(item);
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == item)
                    continue;

                items[i].SetSelected(false);
            }
        }
        else
        {
            SetSelectedItem(null);
        }
    }
    private void SetSelectedItem(BuildItem item)
    {
        selectedItem = item;
        buildButton.interactable = item != null;
    }
}