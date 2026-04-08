using TMPro;
using UnityEngine;

public class BuildingInfoComponent : MonoBehaviour, IHoverable
{
    [SerializeField] private TextMeshProUGUI textComponent;

    private Camera cam;
    private bool isEnabled = false;
    private void Start()
    {
        cam = Camera.main;
        OnHoverExit();
    }
    private void LateUpdate()
    {
        if (!isEnabled)
            return;

        textComponent.transform.LookAt(cam.transform);
        textComponent.transform.Rotate(0, 180, 0);
    }
    public void UpdateText(string text)
    {
        textComponent.text = text;
    }

    public void OnHoverEnter()
    {
        isEnabled = true;
        textComponent.gameObject.SetActive(true);
    }
    public void OnHoverExit()
    {
        isEnabled = false;
        textComponent.gameObject.SetActive(false);
    }
}
