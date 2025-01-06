
using UnityEngine;
using UnityEngine.UI;

public class hand : MonoBehaviour
{
    public hand_take hand_Take;
    public Text held;
    public Image image;
    public bag player_bag;
    private int exist=0;
    void Update(){
        for(int i=0;i<player_bag.itemlist.Count;i++){
            if(player_bag.itemlist[i]==hand_Take.item){
                exist=1;
            }
        }
        if(hand_Take.item!=null && hand_Take.item.held>0 && exist==1){
            image.gameObject.SetActive(true);
            image.sprite=hand_Take.item.item_image;
            held.text=hand_Take.item.held.ToString();
        }
        else{
            hand_Take.item=null;
            image.gameObject.SetActive(false);
            held.text="";
            exist=0;
        }
    }
}
