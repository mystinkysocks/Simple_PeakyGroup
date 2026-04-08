using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CellComponent : MonoBehaviour, IClickable
{
    [field: SerializeField] public float Size { get; private set; } = 1f;
    public BaseBuilding Building { get; private set; }

    private CellEntry entry;
    public void Init(CellEntry entry)
    {
        this.entry = entry;
        if (entry.isOccupied)
        {
            if(ServiceLocator.Instance.TryGet(out BuildingManager service))
            {
                if(service.TryBuild(entry.buildingId, transform.position, out BaseBuilding building))
                {
                    SetBuilding(building);
                }
            }
        }
    }
    public void DeInit()
    {
        Destroy(gameObject);
    }
    public void SetBuilding(BaseBuilding building)
    {
        if (building == null)
            return;

        if (!ServiceLocator.Instance.TryGet(out SaveManager service))
            return;

        Building = building;
        Building.Init(service.GetBuildingEntryById(entry.id));

        entry.isOccupied = true;
        entry.buildingId = building.ID;
    }
    public void OnClick()
    {
        if (Building)
        {
            Building.OnClick();
        }
        else
        {
            if (ServiceLocator.Instance.TryGet(out PopupManager service))
            {
                service.Create<BuildPopup>()?.Init(this);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Size, 0.1f, Size));
    }
}