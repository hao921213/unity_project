using UnityEngine;
using UnityEngine.UI;

public class Fishing_game : MonoBehaviour
{
    public GameObject box;        // 移動範圍的 BoxCollider2D
    public float speed = -2f;        // 移動速度
    public GameObject red;           // 紅色得分區
    public GameObject green;         // 綠色得分區
    public GameObject yellow;        // 黃色得分區
    public Fishing fishing;

    private float minY;              // BoxCollider 的最小 y
    private float maxY;              // BoxCollider 的最大 y
    private float red_minY;          // 紅色區域的最小 y
    private float red_maxY;          // 紅色區域的最大 y
    private float green_minY;        // 綠色區域的最小 y
    private float green_maxY;        // 綠色區域的最大 y
    private float yellow_minY;       // 黃色區域的最小 y
    private float yellow_maxY;       // 黃色區域的最大 y

    private bool isMoving;           // 浮標是否在移動
    private float timeCounter = 0f;


    void Start()
    {
        SetBoundsFromObject();

        // 初始化浮標位置為範圍中心
        transform.position = new Vector3(transform.position.x, (minY + maxY) / 2, transform.position.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetNewTargetPosition();
            isMoving = true;
            speed = -2f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isMoving = false;
            CalculateScore();
        }

        if (isMoving)
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= 0.2f)
            {
                speed += Mathf.Sign(speed); // 根据方向增加速度
                timeCounter = 0f;          // 重置计时器
            }
            if(Mathf.Abs(speed)>=20f){
                if(speed>0){
                    speed=20f;
                }
                else{
                    speed=-20f;
                }
            }
            Move();
        }
    }

    void Move()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        // 到達範圍邊界時反轉速度方向
        if (transform.position.y >= maxY || transform.position.y <= minY)
        {
            speed *= -1;
        }
    }

    void SetBoundsFromObject()
    {
        SpriteRenderer Renderer = box.GetComponent<SpriteRenderer>();
        Bounds bounds = Renderer.bounds;
        float rendererHeight = Renderer.bounds.size.y / 2;
        minY = bounds.min.y-rendererHeight;
        maxY = bounds.max.y-rendererHeight-0.5f;

        // 獲取紅色區域的範圍
        SpriteRenderer redRenderer = red.GetComponent<SpriteRenderer>();
        Bounds rbounds = redRenderer.bounds;
        red_minY = rbounds.min.y-rendererHeight;
        red_maxY = rbounds.max.y-rendererHeight;

        // 獲取綠色區域的範圍
        SpriteRenderer greenRenderer = green.GetComponent<SpriteRenderer>();
        Bounds gbounds = greenRenderer.bounds;
        green_minY = gbounds.min.y-rendererHeight;
        green_maxY = gbounds.max.y-rendererHeight;

        // 獲取黃色區域的範圍
        SpriteRenderer yellowRenderer = yellow.GetComponent<SpriteRenderer>();
        Bounds ybounds = yellowRenderer.bounds;
        yellow_minY = ybounds.min.y-rendererHeight;
        yellow_maxY = ybounds.max.y-rendererHeight;
    }

    void SetNewTargetPosition()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);
    }

    void CalculateScore()
    {
        if (transform.position.y <= green_maxY && transform.position.y >= green_minY)
        {
            Debug.Log("green");
        }
        else if (transform.position.y <= red_maxY && transform.position.y >= red_minY)
        {
            Debug.Log("red");
        }
        else if (transform.position.y <= yellow_maxY && transform.position.y >= yellow_minY)
        {
            Debug.Log("yellow");
        }
        else{
            Debug.Log("white");
        }
        box.SetActive(false);
        red.SetActive(false);
        yellow.SetActive(false);
        green.SetActive(false);
        gameObject.SetActive(false);
        fishing.finish_fish();
        return;
    }

}
