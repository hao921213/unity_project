
using UnityEngine;
using UnityEngine.UI;
public class slot : MonoBehaviour
{
    public int slot_id;
    public item slot_item;
    public Image slot_image;
    public Text slot_num;
    public GameObject item_in_slot;
    public hand_take hand;
    public void SetupSlot(item item){
        if(item == null){
            item_in_slot.SetActive(false);
            return;
        }
        slot_item=item;
        slot_image.sprite=item.item_image;
        slot_num.text=item.held.ToString();
    }
    public void onClicked(){
        if(slot_item!=null){
            hand.item=slot_item;
        }
    }
}
