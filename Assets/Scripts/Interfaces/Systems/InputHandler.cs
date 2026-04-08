using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private void Update()
    {
        OnClickHandler();
    }

    private void OnClickHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<IClickable>(out var clickable))
                {
                    clickable.OnClick();
                }
            }
        }
    }
}