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
            player_bag.itemlist.Add(this_item);
        }
        else{
            this_item.held+=1;
        }
    } 
}
