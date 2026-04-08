using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CellComponent : MonoBehaviour, IClickable
{
    [field: SerializeField] public float Size { get; private set; } = 1f;
    public void Init()
    {
        
    }
    public void DeInit()
    {
        Destroy(gameObject);
    }
    public void OnClick()
    {
        if(ServiceLocator.Instance.TryGet(out PopupManager service))
        {
            var popup = service.Create<BuildPopup>();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Size, 0.1f, Size));
    }
}