using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform target; // 目標物體（如玩家）
    public Vector3 offset = new Vector3(0, 0, -10f);   // 相機與目標的偏移量

    void LateUpdate()
    {
        if (target != null)
        {
            // 更新相機的位置，使其跟隨目標
            transform.position = target.position + offset;
        }
    }
}
