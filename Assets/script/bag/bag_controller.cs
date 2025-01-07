using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class bag_controller : MonoBehaviour
{
    static bag_controller instance;
    public bag player_bag;
    public GameObject slot_grid;
    // public slot slotprefab;
    public GameObject empty_slot;
    public  List<GameObject> slots=new List<GameObject>();
    public Button change_btn;
    public Button sell_btn;
    public hand_take hand;
    public player1 player1;
    static bool ischange = false;
    void Awake() {
        if(instance!=null){
            Destroy(this);
        }    
        instance=this;
    }
    private void Start()
    {
        RefreshItem();
    }
    void Update(){
        if (ischange)
        {
            RefreshItem();
            ischange=false;   
        }
    }
    public static void RefreshItem(){
        for(int i=0;i<instance.slot_grid.transform.childCount;i++){
            Destroy(instance.slot_grid.transform.GetChild(i).gameObject);
        }
        instance.slots.Clear();
        for (int i = 0; i < instance.player_bag.itemlist.Count; i++) {
            GameObject newSlot = Instantiate(instance.empty_slot);
            newSlot.transform.SetParent(instance.slot_grid.transform);
            slot slotComponent = newSlot.GetComponent<slot>();

            slotComponent.slot_id = i;
            if (instance.player_bag.itemlist[i]?.held > 0) {
                slotComponent.SetupSlot(instance.player_bag.itemlist[i]);
            } else {
                if(instance.player_bag.itemlist[i]!=null){
                    instance.player_bag.itemlist[i].held=1;
                }
                instance.player_bag.itemlist[i] = null; // 清除無效物品
                slotComponent.SetupSlot(null); // 重置格子
            }

            instance.slots.Add(newSlot);
        }
    }
    static public void change(){
        ischange=true;
    }
    public void can_change(){
        change_btn.interactable=true;
        sell_btn.interactable=true;
        Debug.Log("can");
    }
    public void cannot_change(){
        change_btn.interactable=false;
        sell_btn.interactable=false;
        Debug.Log("cannot");
    }
    public void sell(){
        if(hand.item!=null){
            hand.item.held-=1;
            player1.money+=(hand.item.price-100);
            if(hand.item.held==0){
                hand.item=null;
            }
            RefreshItem();
        }
    }
}
