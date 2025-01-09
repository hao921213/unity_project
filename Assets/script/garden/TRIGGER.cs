using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TRIGGER : MonoBehaviour
{
    private int enter = 0;
    private Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    public hand_take hand;
    private int find = -1;
    public time1 time1;
    public crop_pic_class carrot;
    public crop_pic_class green_pepper;
    public crop_pic_class pump;
    public crop_pic_class straw;
    public crop_pic_class w_carrot;
    public crop_pic_class watermelon;
    private int time_chack;
    private int phrase = 0;
    private List<string> crop_type = new List<string>{"carrot_seed","green_pepper_seed","pump_seed","straw_seed"
    ,"watermelon_seed","w_carrot_seed"};
    public bag player_bag;
    private void Start()
    {

    }
    void player_get(item item){
        Debug.Log(item);
        int full=-1;
        Debug.Log(player_bag.itemlist.Count);
        for(int i=0;i<player_bag.itemlist.Count;i++){
            if(player_bag.itemlist[i]==item){
                player_bag.itemlist[i].held++;
                bag_controller.RefreshItem();
                return;
            }
        }
        for(int i=0;i<player_bag.itemlist.Count;i++){
            if(player_bag.itemlist[i]==null){
                full=i;
                break;
            }
        }
        if(full!=-1){
            player_bag.itemlist[full]=item;
            bag_controller.RefreshItem();
        }
        else{
            Debug.Log("背包已滿");
        }
        return;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enter = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enter = 0;
        }
    }
    public void update_image()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = hand.item.item_image;
        for (int i = 0; find == -1; i++)
        {
            if(hand.item.item_name == crop_type[i])
            {
                find = i;
                time_chack = time1.hour;
                //Debug.Log("1111time_chack: " + time_chack);
            }
            //Debug.Log("2222time_chack: " + time_chack);
        }
    }
    private void Update()
    {
        if (enter == 1 && Input.GetKeyDown(KeyCode.E) && phrase == 0)
        {
            if (hand.item != null && hand.item.tag == "crop")
            {
                update_image();
                //Debug.Log("find: " + find + " time_chack: " + time_chack + " time1_hour: " + time1.hour);
            }
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (find != -1 && time_chack != time1.hour)
        {
            phrase ++;
            time_chack = time1.hour;
            Debug.Log("phrase: " + phrase);
        }
        switch (find)
        {
            case 0:
                if(phrase == 0)
                {
                    spriteRenderer.sprite = carrot.sprite0;
                    Debug.Log("find: " + find);
                }
                else if(phrase == 1)
                {
                    spriteRenderer.sprite = carrot.sprite1;
                    //Debug.Log("0");
                }
                else if(phrase == 2)
                {
                    spriteRenderer.sprite = carrot.sprite2;
                    //Debug.Log("0");
                }
                else if(phrase == 3)
                {
                    spriteRenderer.sprite = carrot.sprite3;
                    //Debug.Log("0");
                }
                else if(phrase >= 4)
                {
                    spriteRenderer.sprite = carrot.sprite4;
                    if (enter == 1 && Input.GetKeyDown(KeyCode.E))
                    {
                        spriteRenderer.sprite = null;
                        player_get(carrot.item);
                        find = -1;
                        phrase = 0;
                        //Debug.Log("0");
                    }
                }
                break;
            case 1:
                if(phrase == 0)
                {
                    spriteRenderer.sprite = green_pepper.sprite0;
                }
                else if(phrase == 1)
                {
                    spriteRenderer.sprite = green_pepper.sprite1;
                }
                else if(phrase == 2)
                {
                    spriteRenderer.sprite = green_pepper.sprite2;
                }
                else if(phrase == 3)
                {
                    spriteRenderer.sprite = green_pepper.sprite3;
                }
                else if(phrase >= 4)
                {
                    spriteRenderer.sprite = green_pepper.sprite4;
                    if (enter == 1 && Input.GetKeyDown(KeyCode.E))
                    {
                        spriteRenderer.sprite = null;
                        player_get(green_pepper.item);
                        find = -1;
                        phrase = 0;
                    }
                }
                break;
            case 2:

                if(phrase == 0)
                {
                    spriteRenderer.sprite = pump.sprite0;
                }
                else if(phrase == 1)
                {
                    spriteRenderer.sprite = pump.sprite1;
                }
                else if(phrase == 2)
                {
                    spriteRenderer.sprite = pump.sprite2;
                }
                else if(phrase == 3)
                {
                    spriteRenderer.sprite = pump.sprite3;
                }
                else if(phrase >= 4)
                {
                    spriteRenderer.sprite = pump.sprite4;
                    if (enter == 1 && Input.GetKeyDown(KeyCode.E))
                    {
                        spriteRenderer.sprite = null;
                        player_get(pump.item);
                        
                        find = -1;
                        phrase = 0;
                    }
                }
                break;
            case 3:

                if(phrase == 0)
                {
                    spriteRenderer.sprite = straw.sprite0;
                }
                // else if(phrase == 1)
                // {
                //     spriteRenderer.sprite = straw.sprite1;
                // }
                // else if(phrase == 2)
                // {
                //     spriteRenderer.sprite = straw.sprite2;
                // }
                // else if(phrase == 3)
                // {
                //     spriteRenderer.sprite = straw.sprite3;
                // }
                else if(phrase >= 1)
                {
                    spriteRenderer.sprite = straw.sprite4;
                    
                    if (enter == 1 && Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("hi");
                        spriteRenderer.sprite = null;
                        Debug.Log(player_bag.itemlist.Count);
                        player_get(straw.item);
                        find = -1;
                        phrase = 0;
                    }
                    
                }
                break;
            case 4:

                if(phrase == 0)
                {
                    spriteRenderer.sprite = watermelon.sprite0;
                }
                else if(phrase == 1)
                {
                    spriteRenderer.sprite = watermelon.sprite1;
                }
                else if(phrase == 2)
                {
                    spriteRenderer.sprite = watermelon.sprite2;
                }
                else if(phrase == 3)
                {
                    spriteRenderer.sprite = watermelon.sprite3;
                }
                else if(phrase >= 4)
                {
                    spriteRenderer.sprite = watermelon.sprite4;
                    if (enter == 1 && Input.GetKeyDown(KeyCode.E))
                    {
                        spriteRenderer.sprite = null;
                        player_get(watermelon.item);
                        
                        find = -1;
                        phrase = 0;
                    }
                    
                }
                break;
            case 5:
                if(phrase == 0)
                {
                    spriteRenderer.sprite = w_carrot.sprite0;
                }
                else if(phrase == 1)
                {
                    spriteRenderer.sprite = w_carrot.sprite1;
                }
                else if(phrase == 2)
                {
                    spriteRenderer.sprite = w_carrot.sprite2;
                }
                else if(phrase == 3)
                {
                    spriteRenderer.sprite = w_carrot.sprite3;
                }
                else if(phrase >= 4)
                {
                    spriteRenderer.sprite = w_carrot.sprite4;
                    if (enter == 1 && Input.GetKeyDown(KeyCode.E))
                    {
                        spriteRenderer.sprite = null;
                        player_get(w_carrot.item);
                        
                        find = -1;
                        phrase = 0;
                    }
                }
                break;
            default:
                // 當表達式的值不匹配任何 case 時執行此處代碼
                break;
        }
        
    }


}
