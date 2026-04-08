using UnityEngine;

public abstract class BaseBuilding : MonoBehaviour
{
    [field: SerializeField] public string ID { get; private set; }

    public virtual void Init()
    {
        // TODO: Load data
    }
    public abstract void OnClick();
}
