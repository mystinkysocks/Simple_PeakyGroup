using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask hoverMask;
    [SerializeField] private LayerMask clickMask;

    private IHoverable currentHover;

    private void Update()
    {
        HoverHandler();
        ClickHandler();
    }

    private void HoverHandler()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, hoverMask))
        {
            var hover = hit.collider.GetComponent<IHoverable>();

            if (hover != currentHover)
            {
                currentHover?.OnHoverExit();

                currentHover = hover;
                currentHover?.OnHoverEnter();
            }
        }
        else
        {
            currentHover?.OnHoverExit();
            currentHover = null;
        }
    }

    private void ClickHandler()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, clickMask))
        {
            var clickable = hit.collider.GetComponent<IClickable>();

            clickable?.OnClick();
        }
    }
}