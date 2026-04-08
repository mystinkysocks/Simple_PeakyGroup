using TMPro;
using UnityEngine;

public abstract class BaseBuilding : MonoBehaviour
{
    [field: SerializeField] public string ID { get; private set; }
    [SerializeField] private TextMeshProUGUI textComponent;

    public virtual void Init()
    {
        UpdateText($"Type: {ID}");
    }
    public abstract void OnClick();

    protected void UpdateText(string text)
    {
        textComponent.text = text;
    }
}
