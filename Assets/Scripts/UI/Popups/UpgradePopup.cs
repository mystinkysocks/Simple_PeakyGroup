using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePopup : BasePopup
{
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI maxLevelText;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button closeButton;

    private UpgradeBuilding building;
    public void Init(UpgradeBuilding building)
    {
        this.building = building;
        upgradeButton.onClick.AddListener(OnUpgrade);
        closeButton.onClick.AddListener(OnClose);
        UpdateUI();
    }
    private void OnUpgrade()
    {
        building.Upgrade();
        UpdateUI();
    }
    private void OnClose()
    {
        Hide();
    }
    private void UpdateUI()
    {
        currentLevelText.text = $"Current level: {building.Level + 1}";
        maxLevelText.text = $"Max level: {building.MaxLevel}";
    }
}