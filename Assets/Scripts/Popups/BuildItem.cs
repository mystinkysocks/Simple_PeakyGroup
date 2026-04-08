using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuildItem : MonoBehaviour
{
    [SerializeField] private Button buttonComponent;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private GameObject selectedFrame;

    public UnityEvent<BuildItem> onClick = new UnityEvent<BuildItem>();

    public string ID { get; private set; }
    public bool IsSelected {  get; private set; }

    public void Init(string id, string text)
    {
        ID = id;
        textComponent.text = text;
        buttonComponent.onClick.AddListener(OnClick);
        SetSelected(false);
    }
    private void OnClick()
    {
        IsSelected = !IsSelected;
        SetSelected(IsSelected);

        onClick?.Invoke(this);
    }
    public void SetSelected(bool value)
    {
        IsSelected = value;
        selectedFrame.SetActive(value);
    }
}
