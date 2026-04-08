using UnityEngine;

public abstract class BasePopup : MonoBehaviour
{
    public virtual void Show()
    {

    }
    public virtual void Hide() 
    {
        Destroy(gameObject);
    }
}