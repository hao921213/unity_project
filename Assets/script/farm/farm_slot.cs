using UnityEngine;
using UnityEngine.UI;

public class farm_slot : MonoBehaviour
{
    public Image item_image;
    private item currentItem;
    public void SetupSlot(item itemData)
    {
        if (itemData.item_image == null)
        {
            item_image.gameObject.SetActive(false); // 如果沒有圖片，禁用該槽
            return;
        }
        
        // 初始化商品槽
        currentItem = itemData;
        item_image.sprite = itemData.item_image;
    }
    public void onClicked()
    {
        // 通知商店控制器選中該商品
        FindObjectOfType<farm_controller>().SetSelectedItem(gameObject,currentItem);
    }
}
