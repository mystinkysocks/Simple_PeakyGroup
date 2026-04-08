using System.Collections.Generic;
using UnityEngine;

public class UpgradeBuilding : BaseBuilding
{
    [SerializeField] private MeshRenderer meshRenderer;
    [field: SerializeField] public int MaxLevel = 5;
    [SerializeField] private List<Color> colors = new List<Color>();

    public int Level => entry.level;
    public override void Init(BuildingEntry entry)
    {
        base.Init(entry);
        UpdateBuilding();
    }
    public override void OnClick()
    {
        if (ServiceLocator.Instance.TryGet(out PopupManager popupManager))
        {
            popupManager.Create<UpgradePopup>()?.Init(this);
        }
    }

    public void Upgrade()
    {
        if (entry.level >= MaxLevel - 1)
        {
            return;
        }

        entry.level++;
        UpdateBuilding();
    }
    private void UpdateBuilding()
    {
        meshRenderer.material.color = colors[entry.level];
        UpdateText($"Type: {ID}\nLevel: {entry.level + 1}");
    }

    private void OnValidate()
    {
        if (colors.Count > MaxLevel)
        {
            colors.RemoveRange(MaxLevel, colors.Count - MaxLevel);
        }

        while (colors.Count < MaxLevel)
        {
            colors.Add(Color.white);
        }
    }
}