public class UpgradeBuilding : BaseBuilding
{
    public int Level { get; private set; } = 1;
    public int MaxLevel = 3;

    public override void OnClick()
    {
        if (ServiceLocator.Instance.TryGet(out PopupManager popupManager))
        {
            // TODO: Show upgrade panel
        }
    }

    public void Upgrade()
    {
        if (Level >= MaxLevel)
        {
            return;
        }

        Level++;
    }
}