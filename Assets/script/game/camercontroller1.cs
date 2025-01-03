using UnityEngine;

public class cameracontroller1 : MonoBehaviour
{
    public Transform target; // 目标物体（如玩家）
    public Vector3 offset = new Vector3(0, 0, -10f); // 相机与目标的偏移量

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

        // 获取目标的实际位置
        Vector3 rawTargetPosition = target.position + offset;

        transform.position= rawTargetPosition;
    }
}
