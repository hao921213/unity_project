using System;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class oven_trigger : MonoBehaviour
{
    public hand_take hand;
    public bag player_bag;
    public item pork;
    public item steak;
    public item roast_chicken;
    public item roast_sheep;
    private int player_in = 0;
    private item get_item;
    private void Update()
    {
        if (player_in == 1 && Input.GetKeyDown(KeyCode.E))
        {
            if (hand.item != null && hand.item.tag == "meat")
            {
                switch (hand.item.item_name)
                {
                    case "chicken_meat":
                        get_item = roast_chicken;
                        break;
                    case "cow_meat":
                        get_item = steak;
                        break;
                    case "pig_meat":
                        get_item = pork;
                        break;
                    case "sheep_meat":
                        get_item = roast_sheep;
                        break;
                }

                foreach (item item in player_bag.itemlist)
                {
                    if (item != null && item == get_item)
                    {
                        item.held += 1;
                        Debug.Log($"成功: {get_item.item_name} 已更新背包。");
                        hand.item.held -= 1;
                        bag_controller.change();
                        return;
                    }
                }

                // 如果玩家背包沒有該物品，嘗試新增
                for (int i = 0; i < player_bag.itemlist.Count; i++)
                {
                    if (player_bag.itemlist[i] == null)
                    {
                        player_bag.itemlist[i] = get_item;
                        Debug.Log($"成功新增:  到背包。");
                        hand.item.held -= 1;
                        bag_controller.change();
                        return;
                    }
                }
                Debug.LogWarning("玩家背包已滿，無法添加物品！");
            }
            else
            {
                Debug.LogWarning("索引範圍無效，操作取消！");
            }
        }
    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player_in = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player_in = 0;
        }
    }
}
