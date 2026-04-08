using System.Collections.Generic;
using UnityEngine;

public class UpgradeBuilding : BaseBuilding
{
    [SerializeField] private MeshRenderer meshRenderer;
    [field: SerializeField] public int MaxLevel = 5;
    [SerializeField] private List<Color> colors = new List<Color>();
    public int Level { get; private set; } = 0;

    public override void Init()
    {
        base.Init();
        meshRenderer.material.color = colors[Level];
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
        if (Level >= MaxLevel - 1)
        {
            return;
        }

        Level++;
        meshRenderer.material.color = colors[Level];
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