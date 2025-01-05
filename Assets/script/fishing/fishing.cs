using UnityEngine;

public class Fishing : MonoBehaviour
{
    public playercontroller player;
    public GameObject player_pos;      // 玩家位置
    public GameObject rectangleObject; // 矩形範圍物件
    public GameObject itemPrefab;      // 要生成的物品
    public GameObject fish_game1;
    public GameObject fish_game2;
    public GameObject fish_game3;
    public GameObject fish_game4;
    public GameObject fish_game5;
    private GameObject currentItem;    // 當前生成的物品
    private float speed = 1f;          // 物品移動速度
    private float destroyTimer = 0f;   // 計時器
    private bool itemAtPlayer = false; // 物品是否到達玩家
    public int have_fish=0;

    public void Fish()
    {
        // 隨機延遲生成物品
        Invoke("SpawnItems", Random.Range(10, 20));
    }

    void SpawnItems()
    {
        if (rectangleObject == null || player_pos == null)
        {
            Debug.LogError("Rectangle GameObject or Player Position is not assigned!");
            return;
        }

        // 獲取矩形的範圍
        Transform rectTransform = rectangleObject.transform;
        Vector3 rectPosition = rectTransform.position;
        Vector3 rectScale = rectTransform.localScale;

        // 矩形邊界計算
        float xMin = rectPosition.x - rectScale.x / 2;
        float xMax = rectPosition.x + rectScale.x / 2;
        float yMin = rectPosition.y - rectScale.y / 2;
        float yMax = rectPosition.y + rectScale.y / 2;

        // 在矩形範圍內生成隨機位置
        float randomX = Random.Range(xMin, xMax);
        float randomY = Random.Range(yMin, yMax);

        Vector3 randomPosition = new Vector3(randomX, randomY, rectPosition.z);

        // 在隨機位置生成物品
        currentItem = Instantiate(itemPrefab, randomPosition, Quaternion.identity);
        itemAtPlayer = false; // 重置狀態
        destroyTimer = 0f;    // 重置計時器
    }

    void Update()
    {   
        if (currentItem != null)
        {
            Vector3 targetPosition = player_pos.transform.position;

            // 逐漸移動物品到玩家位置
            if (!itemAtPlayer)
            {
                currentItem.transform.position = Vector3.MoveTowards(
                    currentItem.transform.position,
                    targetPosition,
                    speed * Time.deltaTime
                );

                // 如果物品到達玩家位置
                if (Vector3.Distance(currentItem.transform.position, targetPosition) < 0.1f)
                {
                    Debug.Log("Item has reached the player!");
                    player.animator.SetInteger("onfishing",2);
                    itemAtPlayer = true;
                }
            }
            else
            {
                // 開始計時器
                destroyTimer += Time.deltaTime;

                // 如果按下 E 鍵，物品被玩家獲取
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Item collected by player!");
                    Destroy(currentItem);
                    fish_game1.SetActive(true);
                    fish_game2.SetActive(true);
                    fish_game3.SetActive(true);
                    fish_game4.SetActive(true);
                    fish_game5.SetActive(true);
                    currentItem = null;
                    player.animator.SetInteger("onfishing",0);
                    have_fish=1;
                    return;
                }

                // 如果超過 1 秒，銷毀物品
                if (destroyTimer > 1f)
                {
                    Debug.Log("Item destroyed due to timeout!");
                    player.animator.SetInteger("onfishing",0);
                    have_fish=1;
                    Destroy(currentItem);
                }
            }
        }
    }
}
