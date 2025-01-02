using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public Animator animator;    // 動畫控制器
    public GameObject bag;
    public LayerMask obstacleLayer; // 障礙物的圖層，用於檢測

    private bool isopen;
    private Vector3 originalScale; 
    public int money;

    private Rigidbody2D rb; // 用於角色的剛體
    private Vector2 movement; // 儲存移動方向

    void Start()
    {
        money = 0;
        isopen = false;
        bag.SetActive(isopen);
        originalScale = transform.localScale;

        rb = GetComponent<Rigidbody2D>(); // 獲取 Rigidbody2D 組件
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D 未附加到角色上！");
        }

        // 確保 Rigidbody2D 的 Body Type 設為 Kinematic
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        openbag();
        moveInput(); // 處理輸入
    }

    void FixedUpdate()
    {
        TryMove(); // 嘗試移動玩家
    }

    void moveInput()
    {
        movement = Vector2.zero;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // 右
        {
            movement.x = 1f;
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
            animator.SetInteger("Status", 1);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // 左
        {
            movement.x = -1f;
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
            animator.SetInteger("Status", 1);
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // 上
        {
            movement.y = 1f;
            animator.SetInteger("Status", 2);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // 下
        {
            movement.y = -1f;
            animator.SetInteger("Status", 3);
        }
        else
        {
            animator.SetInteger("Status", 0);
        }
    }

    void TryMove()
    {
        if (rb != null)
        {
            // 計算玩家下一幀的位置
            Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

            // 檢測是否碰到障礙物
            Collider2D hit = Physics2D.OverlapCircle(newPosition, 0.1f, obstacleLayer);
            if (hit != null)
            {
                Debug.Log("移動被阻止，檢測到障礙物：" + hit.gameObject.name);
                return; // 如果有障礙物，停止移動
            }

            // 如果沒有障礙物，移動玩家
            rb.MovePosition(newPosition);
        }
    }

    void openbag()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isopen = !isopen;
            bag.SetActive(isopen);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        goshop(coll);
        gofarm(coll);
        gopath(coll);
        gohome(coll);
    }

    void goshop(Collider2D coll)
    {
        if (coll.gameObject.tag == "shop_Portal")
        {
            coll.gameObject.GetComponent<shop_Portal>().ChangeScene_shop();
        }
    }

    void gofarm(Collider2D coll)
    {
        if (coll.gameObject.tag == "farm_Portal")
        {
            coll.gameObject.GetComponent<farm_Portal>().ChangeScene_farm();
        }
    }

    void gopath(Collider2D coll)
    {
        if (coll.gameObject.tag == "path_Portal")
        {
            coll.gameObject.GetComponent<path_Portal>().ChangeScene_path();
        }
    }

    void gohome(Collider2D coll)
    {
        if (coll.gameObject.tag == "house_Portal")
        {
            coll.gameObject.GetComponent<house_portal>().ChangeScene_house();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("與 " + collision.gameObject.name + " 碰撞！");
    }
}
