
using UnityEngine;
using UnityEngine.UI;
public class slot : MonoBehaviour
{
    public item slot_item;
    public Image slot_image;
    public Text slot_num;
    public GameObject item_in_slot;
    public void SetupSlot(item item){
        if(item == null){
            item_in_slot.SetActive(false);
            return;
        }
        slot_image.sprite=item.item_image;
        slot_num.text=item.held.ToString();
    }
}
