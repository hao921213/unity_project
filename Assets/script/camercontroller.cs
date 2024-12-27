using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform target; // 目标物体（如玩家）
    public Vector3 offset = new Vector3(0, 0, -10f); // 相机与目标的偏移量
    public BoxCollider2D sceneBounds; // 场景边界的 BoxCollider2D

    private Camera cam;
    private float camHalfHeight; // 相机高度的一半
    private float camHalfWidth;  // 相机宽度的一半

    void Start()
    {
        // 获取主相机组件
        cam = Camera.main;

        // 计算相机视野范围
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.orthographicSize * cam.aspect;
    }

    void LateUpdate()
    {
        if (target == null || sceneBounds == null)
        {
            Debug.LogError("Target or SceneBounds is not assigned!");
            return;
        }

        // 获取目标的实际位置
        Vector3 rawTargetPosition = target.position + offset;

        // 计算相机允许的移动范围
        float minX = sceneBounds.bounds.min.x + camHalfWidth;
        float maxX = sceneBounds.bounds.max.x - camHalfWidth;
        float minY = sceneBounds.bounds.min.y + camHalfHeight;
        float maxY = sceneBounds.bounds.max.y - camHalfHeight;

        // 应用限制
        float clampedX = Mathf.Clamp(rawTargetPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(rawTargetPosition.y, minY, maxY);

        // 更新相机位置
        transform.position = new Vector3(clampedX, clampedY, rawTargetPosition.z);
    }
}
