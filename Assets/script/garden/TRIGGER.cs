using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TRIGGER : MonoBehaviour
{
    public int number;
    private int enter = 0;
    private SpriteRenderer spriteRenderer;
    public hand_take hand;
    private int find = -1;
    public time1 time1;
    public cropstate state;
    public crop_pic_class carrot;
    public crop_pic_class green_pepper;
    public crop_pic_class pump;
    public crop_pic_class straw;
    public crop_pic_class w_carrot;
    public crop_pic_class watermelon;
    public Animator animator;
    private int time;
    private int time_chack;
    private int phrase = -1;
    private List<string> crop_type = new List<string>{"carrot_seed","green_pepper_seed","pump_seed","straw_seed"
    ,"watermelon_seed","w_carrot_seed"};
    public bag player_bag;
    private int watered = 0;
    private int stop_hour;
    private int stop_day;
    private int pass_hour;

    void time_pass_calculate()
    {
        if (phrase != -1 && watered ==1 && stop_hour != time1.hour)
        {
            if(stop_day == time1.day){
                pass_hour = time1.hour - stop_hour;
                phrase = phrase + pass_hour;
                save_phase(phrase);
            }
            else{
                pass_hour = 24 - stop_hour + 24 * (time1.day - stop_day -1) + time1.hour;
                phrase = phrase + pass_hour;
                save_phase(phrase);
            }
        }
    }
    private void Start()
    {
        phrase = state.crop_phase[number-1];
        find = state.crop_type[number-1];
        watered = state.crop_watered[number-1];
        time_pass_calculate();
        Debug.Log("phrase: " + phrase);
        Debug.Log("find: " + find);
    }
    void after_used(item item)
    {
        for(int i=0;i<player_bag.itemlist.Count;i++){
            if(player_bag.itemlist[i]==item){
                player_bag.itemlist[i].held--;
                bag_controller.RefreshItem();
                return;
            }
        }
        return;
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
                save_type(find);
            }
        }
    }
    
    private void save_phase(int a)
    {
        state.crop_phase[number-1] = a;
    }
    private void save_type(int a)
    {
        state.crop_type[number-1] = a;
    }
    private void save_water(int a)
    {
        state.crop_watered[number-1] = a;
    }
    void phrase_switch(crop_pic_class crop)
    {
        if(phrase == 0)
        {
            spriteRenderer.sprite = crop.sprite0;
        }
        else if(phrase == 1)
        {
            spriteRenderer.sprite = crop.sprite1;
        }
        else if(phrase == 2)
        {
            spriteRenderer.sprite = crop.sprite2;
        }
        else if(phrase == 3)
        {
            spriteRenderer.sprite = crop.sprite3;
        }
        else if(phrase >= 4)
        {
            spriteRenderer.sprite = crop.sprite4;
            if (enter == 1 && Input.GetKeyDown(KeyCode.E))
            {
                spriteRenderer.sprite = null;
                player_get(crop.item);
                find = -1;
                phrase = -1;
                watered = 0;
                save_phase(phrase);
                save_type(find);
                save_water(0);
            }
        }
    }
    void water()
    {
        animator.SetInteger("onwater",1);
        watered = 1;
        save_water(1);
    }
    private void Update()
    {
        if (enter == 1 && Input.GetKeyDown(KeyCode.E) && phrase == -1)
        {
            if (hand.item != null && hand.item.tag == "crop")
            {
                update_image();
                after_used(hand.item);
                phrase = 0;//註掉
                save_phase(phrase);
            }
        }
        if (enter == 1 && Input.GetKeyDown(KeyCode.E) && phrase == 0)
        {
            if (hand.item != null && hand.item.item_name == "waterer")
            {
                water();
            }
        }
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (find != -1 && time_chack != time1.hour) //&& watered == 1
        {
            phrase ++;
            save_phase(phrase);
            time_chack = time1.hour;
        }
        switch (find)
        {
            case 0:
                phrase_switch(carrot);
                break;
            case 1:
                phrase_switch(green_pepper);
                break;
            case 2:
                phrase_switch(pump);
                break;
            case 3:
                phrase_switch(straw);
                break;
            case 4:
                phrase_switch(watermelon);
                break;
            case 5:
                phrase_switch(w_carrot);
                break;
            default:
                break;
        }
        stop_hour = time1.hour;
        state.stop_hour[number-1] = stop_hour;
        stop_day = time1.day;
        state.stop_day[number-1] = stop_day;
        
    }

}
