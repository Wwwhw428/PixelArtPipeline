using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DrawOrthoCameraGizmo : MonoBehaviour
{
    private Camera _camera;

    private void OnDrawGizmos()
    {
        _camera = GetComponent<Camera>();

        if (_camera.orthographic)
        {
            DrawOrthographicCameraBounds();
        }
    }

    private void DrawOrthographicCameraBounds()
    {
        float height = _camera.orthographicSize * 2.0f;
        float width = height * _camera.aspect;

        Vector3 topLeft = transform.position + transform.forward * _camera.nearClipPlane;
        topLeft += transform.up * height * 0.5f;
        topLeft -= transform.right * width * 0.5f;

        Vector3 topRight = topLeft + transform.right * width;
        Vector3 bottomLeft = topLeft - transform.up * height;
        Vector3 bottomRight = bottomLeft + transform.right * width;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }
}
