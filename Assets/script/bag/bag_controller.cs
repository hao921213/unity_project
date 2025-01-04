using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class bag_controller : MonoBehaviour
{
    static bag_controller instance;
    public bag player_bag;
    public GameObject slot_grid;
    // public slot slotprefab;
    public GameObject empty_slot;
    public  List<GameObject> slots=new List<GameObject>();
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
    // public static void CreateNewItem(item item){
    //     slot newItem=Instantiate(instance.slotprefab,instance.slot_grid.transform.position,Quaternion.identity);
    //     newItem.gameObject.transform.SetParent(instance.slot_grid.transform);
    //     newItem.slot_item=item;
    //     newItem.slot_image.sprite=item.item_image;
    //     newItem.slot_num.text=item.held.ToString();
    // }
    public static void RefreshItem(){
        for(int i=0;i<instance.slot_grid.transform.childCount;i++){
            if(instance.slot_grid.transform.childCount==0){
                break;
            }
            Destroy(instance.slot_grid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        for(int i=0;i<instance.player_bag.itemlist.Count;i++){
            // CreateNewItem(instance.player_bag.itemlist[i]);
            instance.slots.Add(Instantiate(instance.empty_slot));
            instance.slots[i].transform.SetParent(instance.slot_grid.transform); 
            instance.slots[i].GetComponent<slot>().slot_id=i;
            instance.slots[i].GetComponent<slot>().SetupSlot(instance.player_bag.itemlist[i]);
        }
    }
    static public void change(){
        ischange=true;
    }
}
