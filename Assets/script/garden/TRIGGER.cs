using UnityEngine;
using UnityEngine.UI;

public class TRIGGER : MonoBehaviour
{
    private int enter = 0;
    private cropstate crop;
    private Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    public hand_take hand;
    private int find;


    private void Start()
    {
        crop.crop_type[0] = "carrot_seed";
        crop.crop_type[1] = "green_pepper_seed";
        crop.crop_type[2] = "pump_seed";
        crop.crop_type[3] = "straw_seed";
        crop.crop_type[4] = "watermelon_seed";
        crop.crop_type[5] = "w_carrot_seed";
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
        for (int i = 0; find == 0; i++)
        {
            if(hand.item.item_name == crop.crop_type[i])
            {
                find = i;
            }
        }
    }
    private void Update()
    {
        if (enter == 1 && Input.GetKeyDown(KeyCode.E))
        {
            if (hand.item != null && hand.item.tag == "crop")
            {
                find = 0;
                update_image();
            }
        }

    }

}
