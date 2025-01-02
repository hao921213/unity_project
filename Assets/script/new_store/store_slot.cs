using UnityEngine;
using UnityEngine.UI;

public class store_slot : MonoBehaviour
{
    public string item_info; 
    public Image item_image;
    public Text item_held;
    public Text inform;
    public Text price_text;
    public int price;
    public void SetupSlot(item itemData, Text informationDisplay,Text money)
    {
        if (itemData != null)
        {
            item_image.sprite = itemData.item_image;
            item_held.text = itemData.held.ToString();
            item_info = itemData.iteminfo;
            price=itemData.price;
            inform = informationDisplay;
            price_text=money;
        }
    }
    public void onClicked(){
        inform.text=item_info;
        price_text.text=price.ToString();
    }
}
