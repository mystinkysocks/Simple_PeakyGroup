using UnityEngine;

public abstract class BasePopup<TData> : MonoBehaviour
{
    public abstract void Init(TData data);
}