using Unity.VisualScripting;
using UnityEngine;

public class item_onworld : MonoBehaviour
{
    public item this_item;
    public bag player_bag;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            AddNewItem();
            Destroy(gameObject);
        }
    }
    public void AddNewItem(){
        if(!player_bag.itemlist.Contains(this_item)){
            // player_bag.itemlist.Add(this_item);
            // bag_controller.CreateNewItem(this_item);
            for(int i=0;i<player_bag.itemlist.Count;i++){
                if(player_bag.itemlist[i]==null){
                    player_bag.itemlist[i]=this_item;
                    break;
                }
            }
        }
        else{
            this_item.held+=1;
        }
        bag_controller.RefreshItem();
    } 
}
