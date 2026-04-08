using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Zoom Settings")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;

    private void Update()
    {
        Zoom();
    }

    private void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Approximately(scroll, 0f))
            return;

        Vector3 dir = (target.position - cam.transform.position).normalized;
        Vector3 newPos = cam.transform.position + dir * scroll * zoomSpeed;

        float distance = Vector3.Distance(newPos, target.position);
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        cam.transform.position = target.position - dir * distance;
    }
}
