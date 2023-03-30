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

        Gizmos.color = Color.green;

        # region near clip plane
        Vector3 nearTopLeft = transform.position + transform.forward * _camera.nearClipPlane;
        nearTopLeft += transform.up * height * 0.5f;
        nearTopLeft -= transform.right * width * 0.5f;

        Vector3 nearTopRight = nearTopLeft + transform.right * width;
        Vector3 nearBottomLeft = nearTopLeft - transform.up * height;
        Vector3 nearBottomRight = nearBottomLeft + transform.right * width;

        Gizmos.DrawLine(nearTopLeft, nearTopRight);
        Gizmos.DrawLine(nearTopRight, nearBottomRight);
        Gizmos.DrawLine(nearBottomRight, nearBottomLeft);
        Gizmos.DrawLine(nearBottomLeft, nearTopLeft);
        # endregion

        # region far clip plane
        Vector3 farTopLeft = transform.position + transform.forward * _camera.farClipPlane;
        farTopLeft += transform.up * height * 0.5f;
        farTopLeft -= transform.right * width * 0.5f;

        Vector3 farTopRight = farTopLeft + transform.right * width;
        Vector3 farBottomLeft = farTopLeft - transform.up * height;
        Vector3 farBottomRight = farBottomLeft + transform.right * width;

        Gizmos.DrawLine(farTopLeft, farTopRight);
        Gizmos.DrawLine(farTopRight, farBottomRight);
        Gizmos.DrawLine(farBottomRight, farBottomLeft);
        Gizmos.DrawLine(farBottomLeft, farTopLeft);
        # endregion

        # region top left right bottom
        Gizmos.DrawLine(farTopLeft, nearTopLeft);
        Gizmos.DrawLine(farTopRight, nearTopRight);
        Gizmos.DrawLine(farBottomRight, nearBottomRight);
        Gizmos.DrawLine(farBottomLeft, nearBottomLeft);
        # endregion
    }
}