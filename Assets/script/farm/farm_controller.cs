using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class farm_controller : MonoBehaviour
{
    public bag farm;
    public bag player_bag;
    public hand_take hand;
    public Text text;
    public Image animal_image; 
    public GameObject slot_prefab;
    public GameObject slot_grid;
    private item selectedanimal;
    private List<GameObject> slots = new List<GameObject>(); 
    private void Update(){
        update_hand_slot();
    }
    private void Start(){
        update_animal_slot();
    }
    public void update_hand_slot(){
        if(hand.item!=null && hand.item.tag=="animal"){
            animal_image.gameObject.SetActive(true);
            animal_image.sprite=hand.item.item_image;
        }
        else{
            animal_image.gameObject.SetActive(false);
        }
    }
    public void update_animal_slot(){
        foreach (var slot in slots)
        {
            Destroy(slot);
        }
        slots.Clear();
        for(int i=0;i<farm.itemlist.Count;i++){
            GameObject newSlot = Instantiate(slot_prefab, slot_grid.transform);
            farm_slot slotComponent = newSlot.GetComponent<farm_slot>();
            slotComponent.SetupSlot(farm.itemlist[i]);
            slots.Add(newSlot);
        }
    }
    public void push(){
        if(hand.item!=null){
            if(farm.itemlist.Count<7){
                for(int i=0;i<farm.itemlist.Count;i++){
                    if(farm.itemlist[i].tag=="none"){
                        farm.itemlist[i]=hand.item;
                        update_animal_slot();
                        break;
                    }
                }
                foreach(item item in player_bag.itemlist){
                    if(item!=null && item==hand.item){
                        item.held -= 1;
                        Debug.Log($"push成功: {hand.item.item_name}");
                        bag_controller.change();
                        return;
                    }
                }
            }
        }
    }
    public void get(){
        if(player_bag.itemlist.Count<17){
            foreach(item item in player_bag.itemlist){
                if(item!=null && item.item_name==selectedanimal.item_name){
                    item.held += 1;
                    Debug.Log($"購買成功: {selectedanimal.item_name}");
                    bag_controller.change();
                    return;
                }
            }
            // 如果玩家背包沒有該物品，添加新物品
            for(int i=0;i<player_bag.itemlist.Count;i++){
                if(player_bag.itemlist[i]==null){
                    player_bag.itemlist[i]=selectedanimal;
                    Debug.Log($"購買成功: {selectedanimal.item_name}");
                    bag_controller.change();
                    return;
                }
            }
        }
    }
    public void SetSelectedItem(item selected)
    {
        selectedanimal = selected;
    }
}
