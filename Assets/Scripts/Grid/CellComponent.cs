using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CellComponent : MonoBehaviour, IClickable
{
    [field: SerializeField] public float Size { get; private set; } = 1f;

    public BaseBuilding Building { get; private set; }
    public void Init()
    {
        
    }
    public void DeInit()
    {
        Destroy(gameObject);
    }
    public void SetBuilding(BaseBuilding building)
    {
        Building = building;
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