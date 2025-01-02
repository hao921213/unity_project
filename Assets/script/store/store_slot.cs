using UnityEngine;
using UnityEngine.UI;

public class store_slot : MonoBehaviour
{
    public string item_info;
    public Image item_image;
    public Text inform;
    public Text price_text;
    public int price;
    private item currentItem;

    public void SetupSlot(item itemData, Text informationDisplay, Text money)
    {
        if (itemData.item_image == null)
        {
            gameObject.SetActive(false); // 如果沒有圖片，禁用該槽
            return;
        }

        // 初始化商品槽
        currentItem = itemData;
        item_image.sprite = itemData.item_image;
        item_info = itemData.iteminfo;
        price = itemData.price;
        inform = informationDisplay;
        price_text = money;
    }

    public void onClicked()
    {
        // 更新商品信息顯示
        inform.text = item_info;
        price_text.text = price.ToString();

        // 通知商店控制器選中該商品
        FindObjectOfType<store_controller>().SetSelectedItem(currentItem);
    }
}
