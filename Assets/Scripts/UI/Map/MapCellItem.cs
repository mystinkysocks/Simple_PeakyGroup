using TMPro;
using UnityEngine;

public class MapCellItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;

    public void UpdateText(CellComponent cell)
    {
        if (cell.Building)
        {
            textComponent.text = cell.Building.ID;
        }
        else
        {
            textComponent.text = "*";
        }
    }
}
