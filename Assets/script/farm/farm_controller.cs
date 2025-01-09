using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;

public class farm_controller : MonoBehaviour
{
    public bag farm;
    public water_controller grow;
    public bag player_bag;
    public item empty;
    public hand_take hand;
    public Text text;
    public Image animal_image; 
    public GameObject slot_prefab;
    public GameObject slot_grid;
    public Transform right;
    public Transform left;
    public water_controller all_waters;
    public int index;
    public time1 time;
    public animals_grow animals_grow;
    public Text info;
    public List<GameObject> animals = new List<GameObject>();
    public item chicken_meat;
    public item cow_meat;
    public item sheep_meat;
    public item pig_meat;
    private item selectedanimal;
    private GameObject click_slot;
    private List<GameObject> slots = new List<GameObject>();
    private int has=0;
    private int change;
    private item meat;
    private void Update(){
        update_hand_slot();
    }
    private void Start(){
        update_animal_slot();
        update_animal();
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

    public void update_animal(){
        foreach (var animal in animals)
        {
            Destroy(animal);
        }
        animals.Clear();
        for (int i = 0; i < farm.itemlist.Count; i++)
        {
            if (farm.itemlist[i] != null && farm.itemlist[i].item_name != "null")
            {
                GameObject new_animal = Instantiate(farm.itemlist[i].prefab, new Vector3(Random.Range(left.position.x, right.position.x
                ), Random.Range(left.position.y, right.position.y), 0), Quaternion.identity);
                animals.Add(new_animal);
                farm_animal_move farm_move = new_animal.GetComponent<farm_animal_move>();
                update_animal_size();
                farm_move.rangeObjectMin = left;
                farm_move.rangeObjectMax = right;
            }
        }
    }
    public void update_animal_size()
    {
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i] != null)
            {
                animals[i].transform.localScale = new Vector3(1+ grow.waters[i] * 0.05f, 1 + grow.waters[i] * 0.05f, 1);
            }
        }
    }
    public void push(){
        if(hand.item!=null && hand.item.tag=="animal"){
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
                        update_animal();
                        bag_controller.change();
                        return;
                    }
                }
            }
        }
    }
    public void get()
    {
        if (click_slot == null || selectedanimal == null)
        {
            info.text = "";
            Debug.LogWarning("未選擇任何物品或槽位！");
            return;
        }
        // 根據點擊的槽位找到對應的索引
        int index = slots.IndexOf(click_slot);
        if (index == -1)
        {
            Debug.LogWarning("槽位未找到，操作取消！");
            return;
        }
        if (grow.waters[index] >= selectedanimal.grow)
        {
            
            switch (selectedanimal.item_name)
            {
                case "chicken_l1":
                case "chicken_l2":
                case "chicken_l3":
                    meat = chicken_meat;
                    break;
                case "cow_l1":
                case "cow_l2":
                case "cow_l3":
                    meat = cow_meat;
                    break;
                case "pig_l1":
                case "pig_l2":
                case "pig_l3":
                    meat = pig_meat;
                    break;
                case "sheep_l1":
                case "sheep_l2":
                case "sheep_l3":
                case "sheep_l4":
                case "sheep_l5":
                    meat = sheep_meat;
                    break;
            }
            // 確保索引範圍合法
            if (index >= 0 && index < farm.itemlist.Count)
            {
                // 從玩家背包中檢查是否已有該物品
                foreach (item item in player_bag.itemlist)
                {
                    if (item != null && item == meat)
                    {
                        item.held += 1;
                        Debug.Log($"成功: {meat.item_name} 已更新背包。");

                        // 將農場槽位設置為空
                        farm.itemlist[index] = empty;
                        bag_controller.change();
                        update_animal_slot();
                        update_animal();
                        return;
                    }
                }

                // 如果玩家背包沒有該物品，嘗試新增
                for (int i = 0; i < player_bag.itemlist.Count; i++)
                {
                    if (player_bag.itemlist[i] == null)
                    {
                        player_bag.itemlist[i] = meat;
                        Debug.Log($"成功新增:  到背包。");

                        // 將農場槽位設置為空
                        farm.itemlist[index] = empty;
                        bag_controller.change();
                        update_animal_slot();
                        update_animal();
                        return;
                    }
                }
                info.text = "玩家背包已滿，無法添加物品";
                Debug.LogWarning("玩家背包已滿，無法添加物品！");
            }
            else
            {
                info.text = "";
                Debug.LogWarning("索引範圍無效，操作取消！");
            }
        }
        else
        {
            info.text = "";
            Debug.Log("還沒成熟");
        }
    }

    public void SetSelectedItem(GameObject slot,item select)
    {
        selectedanimal = select;
        click_slot = slot;
        int index = slots.IndexOf(click_slot);
        if (index != -1) {
            info.text = $"成熟期:{select.grow} 目前年紀:{grow.waters[index]}";
        }
        
    }
}
