using UnityEngine;

public class farm_animal_move : MonoBehaviour
{
    public Transform rangeObjectMin; // 定義移動範圍的左下角物件
    public Transform rangeObjectMax; // 定義移動範圍的右上角物件
    public float moveSpeed = 2f;      // 動物移動速度
    public float pauseTime = 2f;     // 暫停移動的時間
    private Animation animate;
    private Vector3 targetPosition;  // 動物目標位置
    private bool isMoving = false;

    void Start()
    {
        // animate=GetComponent<>
        SetRandomTarget();
    }

    void Update()
    {
        MoveToTarget();
    }

    // 設定隨機目標位置
    private void SetRandomTarget()
    {
        if (rangeObjectMin != null && rangeObjectMax != null)
        {
            Vector2 min = rangeObjectMin.transform.position;
            Vector2 max = rangeObjectMax.transform.position;

            targetPosition = new Vector3(
                Random.Range(min.x, max.x),
                Random.Range(min.y, max.y),
                transform.position.z
            );
            isMoving = true;
        }
        else
        {
            Debug.LogError("範圍物件未設定");
        }
    }

    // 移動到目標位置
    private void MoveToTarget()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 如果到達目標位置，停止移動並設定下一個目標
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                Invoke(nameof(SetRandomTarget), pauseTime); // 暫停一段時間後移動到下一個目標
            }
        }
    }
}
