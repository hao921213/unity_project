
using UnityEngine;
using UnityEngine.UI;

public class hand : MonoBehaviour
{
    public hand_take hand_Take;
    public Text held;
    public Image image;
    void Update(){
        if(hand_Take.item!=null){
            image.gameObject.SetActive(true);
            image.sprite=hand_Take.item.item_image;
            held.text=hand_Take.item.held.ToString();
        }
        else{
            image.gameObject.SetActive(false);
        }
    }
}
