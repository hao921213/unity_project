using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f; // 移动速度
    public Animator animator;    // 动画控制器
    public GameObject bag;
    private bool isopen;
    private Vector3 originalScale; 

    void Start()
    {
        isopen=false;
        bag.SetActive(isopen);
        originalScale = transform.localScale;
    }

    void Update()
    {
        openbag();
        move();
    }
    void move(){
        float moveX = 0f;
        float moveY = 0f;

        // 检测具体按键
        if (Input.GetKey(KeyCode.D)) // 右
        {
            moveX = 1f;
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
            animator.SetInteger("Status", 1);
        }
        else if (Input.GetKey(KeyCode.A)) // 左
        {
            moveX = -1f;
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
            animator.SetInteger("Status", 1);
        }
        else if (Input.GetKey(KeyCode.W)) // 上
        {
            moveY = 1f;
            animator.SetInteger("Status", 2);
        }
        else if (Input.GetKey(KeyCode.S)) // 下
        {
            moveY = -1f;
            animator.SetInteger("Status", 3);
        }
        else
        {
            animator.SetInteger("Status", 0); 
        }

        // 移动角色
        Vector3 movement = new Vector3(moveX, moveY, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
    void openbag(){
        if(Input.GetKeyDown(KeyCode.F)){
            isopen=!isopen;
            bag.SetActive(isopen);
        }
    }
}
