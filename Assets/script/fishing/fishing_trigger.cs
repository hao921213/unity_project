using UnityEngine;

public class fishing_trigger : MonoBehaviour
{
    private bool isPlayerInArea = false; // 檢查玩家是否在目標區域
    public hand_take hand;
    public playercontroller player;
    public Fishing fish;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // 確認進入範圍的是否是玩家
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInArea = true;
            Debug.Log("Player has entered the target area.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 確認離開範圍的是否是玩家
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInArea = false;
            Debug.Log("Player has left the target area.");
        }
    }

    void Update()
    {
        // 如果玩家在範圍內，並按下指定鍵（例如 E 鍵）

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            player.animator.SetInteger("onfishing",3);
        }
        else if (isPlayerInArea && Input.GetKeyDown(KeyCode.E) && hand.item.item_name=="fishing_rod")
        {
            TriggerCondition();
        }
    }

    private void TriggerCondition()
    {
        // 處理觸發條件的邏輯
        Debug.Log("Condition triggered! Executing action...");
        player.animator.SetInteger("onfishing",1);
        fish.Fish();
    }
}

