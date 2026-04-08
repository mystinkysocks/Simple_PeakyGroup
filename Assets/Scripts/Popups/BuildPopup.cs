using System.Collections.Generic;
using UnityEngine;
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

    private void Start()
    {
        buildButton.onClick.AddListener(OnBuildButton);
        closeButton.onClick.AddListener(OnCloseButton);

        for (int i = 0; i < 2; i++)
        {
            var item = Instantiate(prefab, container);
            item.Init($"Type: {i}");
            item.onClick.AddListener(OnClick);
            items.Add(item);
        }

        SetSelectedItem(null);
    }
    private void OnBuildButton()
    {

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