using UnityEngine;

public class animal_move : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 5f; // 速度可調整
    private SpriteRenderer sprite;
    private Transform posRight;
    private Transform posLeft;
    private float renavigation_timer;
    public LayerMask obstacleLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        posLeft = this.transform.parent.GetChild(2);
        posRight = this.transform.parent.GetChild(1);
    }

    private void FixedUpdate()
    {
        renavigation_timer -= Time.fixedDeltaTime;

        // 範圍檢查
        if (transform.position.x < posLeft.position.x || transform.position.x > posRight.position.x ||
            transform.position.y < posLeft.position.y || transform.position.y > posRight.position.y)
        {
            renavigation_timer = 0f;
            transform.position = new Vector2(
                Mathf.Clamp(transform.position.x, posLeft.position.x, posRight.position.x),
                Mathf.Clamp(transform.position.y, posLeft.position.y, posRight.position.y)
            );
        }

        // 如果計時器到期，重新導航
        if (renavigation_timer <= 0)
        {
            // 隨機選擇目標位置
            Vector2 randomPos = new Vector2(
                Random.Range(posLeft.position.x, posRight.position.x),
                Random.Range(posLeft.position.y, posRight.position.y)
            );

            // 計算移動方向
            Vector2 dir = (randomPos - (Vector2)this.transform.position).normalized;

            // 翻轉 Sprite 朝向
            sprite.flipX = dir.x > 0;

            // 檢測是否碰到障礙物
            Collider2D hit = Physics2D.OverlapCircle(transform.position, 0.1f, obstacleLayer);
            if (hit != null)
            {
                Debug.Log("移動被阻止，檢測到障礙物：" + hit.gameObject.name);
                return; // 如果有障礙物，停止移動
            }

            // 設置速度
            rb.linearVelocity = dir * speed;

            // 重置計時器
            renavigation_timer = 2f;
        }
    }
}