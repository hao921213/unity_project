using UnityEngine;
using UnityEngine.UI;

public class store_slot : MonoBehaviour
{
    public string item_info; 
    public Image item_image;
    public Text item_held;

    public void SetupSlot(item itemData)
    {
        if (itemData != null)
        {
            item_image.sprite = itemData.item_image;
            item_held.text=itemData.held.ToString();
            item_info=itemData.iteminfo;
        }
    }
}
