using TMPro;
using UnityEngine;

public abstract class BaseBuilding : MonoBehaviour
{
    [field: SerializeField] public string ID { get; private set; }
    [SerializeField] private TextMeshProUGUI textComponent;

    protected BuildingEntry entry;
    public virtual void Init(BuildingEntry entry)
    {
        this.entry = entry;
        UpdateText($"Type: {ID}");
    }
    public abstract void OnClick();

    protected void UpdateText(string text)
    {
        textComponent.text = text;
    }
}
