
using UnityEngine;
using UnityEngine.UI;

public class hand : MonoBehaviour
{
    public hand_take hand_Take;
    public Text held;
    public Image image;
    void Update(){
        if(hand_Take.item!=null && hand_Take.item.held>0){
            image.gameObject.SetActive(true);
            image.sprite=hand_Take.item.item_image;
            held.text=hand_Take.item.held.ToString();
        }
        else{
            hand_Take.item=null;
            image.gameObject.SetActive(false);
            held.text="";
        }
    }
}
