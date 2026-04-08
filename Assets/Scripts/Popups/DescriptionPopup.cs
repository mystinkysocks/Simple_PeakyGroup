using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionPopup : BasePopup
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Button closeButton;

    public void Init(string name, string description)
    {
        nameText.text = name;
        descriptionText.text = description;
        closeButton.onClick.AddListener(OnClose);
    }

    private void OnClose() => Hide();
}