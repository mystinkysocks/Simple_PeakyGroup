using UnityEngine;

public class DescriptionBuilding : BaseBuilding
{
    [SerializeField] private string nameText;
    [SerializeField] private string descriptionText;

    public override void OnClick()
    {
        if (ServiceLocator.Instance.TryGet(out PopupManager popupManager))
        {
            // TODO: Show description panel
        }
    }
}