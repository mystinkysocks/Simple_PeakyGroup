using TMPro;
using UnityEngine;

public abstract class BaseBuilding : MonoBehaviour
{
    [field: SerializeField] public string ID { get; private set; }
    [SerializeField] protected BuildingInfoComponent infoComponent;

    protected BuildingEntry entry;
    public virtual void Init(BuildingEntry entry)
    {
        this.entry = entry;
        infoComponent.UpdateText($"Type: {ID}");
    }
    public abstract void OnClick();
}
