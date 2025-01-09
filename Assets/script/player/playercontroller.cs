using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public Animator animator;    // 動畫控制器
    public GameObject bag;
    public LayerMask obstacleLayer; // 障礙物的圖層，用於檢測
    public hand_take hand;

    private bool isopen;
    private Vector3 originalScale; 

    private Rigidbody2D rb; // 用於角色的剛體
    private Vector2 movement; // 儲存移動方向
    public player1 hp;
    public health_bar health_change;
    private int direction=0;

    void Start()
    {
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
        use();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy1")
        {
            health_change.TakeDamage(1);
            print(hp.health);
            if (hp.health == 0)
            {
                SceneManager.LoadScene("Home");
                hp.health = 10;
            }
        }
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

            if (hand.item != null && hand.item.item_name == "torch")
            {
                animator.SetInteger("Status", 7);
            }
            else
            {
                animator.SetInteger("Status", 1);
            }
            direction =3;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // 左
        {
            movement.x = -1f;
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
            direction=1;
            if (hand.item != null && hand.item.item_name == "torch")
            {
                animator.SetInteger("Status", 7);
            }
            else
            {
                animator.SetInteger("Status", 1);
            }
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // 上
        {
            movement.y = 1f;
            if (hand.item != null && hand.item.item_name == "torch")
            {
                animator.SetInteger("Status", 6);
            }
            else
            {
                animator.SetInteger("Status", 2);
            }
            direction =2;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // 下
        {
            movement.y = -1f;
            if (hand.item != null && hand.item.item_name == "torch")
            {
                animator.SetInteger("Status", 5);
            }
            else
            {
                animator.SetInteger("Status", 3);
            }
            direction =0;
        }
        else
        {
            if (hand.item!=null && hand.item.item_name == "torch")
            {
                animator.SetInteger("Status", 4);
            }
            else {
                animator.SetInteger("Status", 0);
            }
            
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
        if (Input.GetKeyDown(KeyCode.Tab))
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
        goGarden(coll);
        gofishing(coll);
        gosforest(coll);
        gobed(coll);
        
    }

    void goshop(Collider2D coll)
    {
        if (coll.gameObject.tag == "shop_Portal")
        {
            coll.gameObject.GetComponent<shop_Portal>().ChangeScene_shop();
        }
    }

    void gosforest(Collider2D coll)
    {
        if (coll.gameObject.tag == "forest_Portal")
        {
            coll.gameObject.GetComponent<forest_Prtal>().ChangeScene_forest();
        }
    }

    void gofishing(Collider2D coll)
    {
        if (coll.gameObject.tag == "fishing_Portal")
        {
            coll.gameObject.GetComponent<fishing_Portal>().ChangeScene_fish();
        }
    }

    void goGarden(Collider2D coll)
    {
        if (coll.gameObject.tag == "Garden_Portal")
        {
            coll.gameObject.GetComponent<Garden_Portal>().ChangeScene_Garden();
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

    void gobed(Collider2D coll)
    {
        if (coll.gameObject.tag == "bed_Portal")
        {
            coll.gameObject.GetComponent<bed_Portal>().ChangeScene_bed();
        }
    }

    public void use(){
        if(Input.GetKeyDown(KeyCode.E) && hand.item==null){
            attack();
        }
        else if(Input.GetKeyDown(KeyCode.E) && hand.item.item_name=="sword"){
            attack();    
        }
    }

    
    void attack(){
        if(hand.item==null){
            
            switch(direction){
                case 0:
                    animator.SetInteger("onattack",0);
                    break;
                case 1:
                    transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
                    animator.SetInteger("onattack",3);
                    break;
                case 2:
                    animator.SetInteger("onattack",2);
                    break;
                case 3:
                    transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
                    animator.SetInteger("onattack",3);
                    break;
            }
        }
        else if(hand.item.item_name=="sword"){
            switch(direction){
                case 0:
                    animator.SetInteger("sword",0);
                    break;
                case 1:
                    transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
                    animator.SetInteger("sword",3);
                    break;
                case 2:
                    animator.SetInteger("sword",2);
                    break;
                case 3:
                    transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
                    animator.SetInteger("sword",3);
                    break;
            }
        }
    }
    
}
