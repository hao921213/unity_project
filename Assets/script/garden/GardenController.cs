using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class GardenController : MonoBehaviour
{
    public hand_take hand;
    public Image crops_image;
    public cropstate crop;
    public GameObject sign;
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;

    private void Update()
    {
        update_image();
    }
    public void update_image()
    {
        if (hand.item != null && hand.item.tag == "crop")
        {
            crops_image.gameObject.SetActive(true);
            crops_image.sprite = hand.item.item_image;
            SpriteRenderer spriteRendererA = A.GetComponent<SpriteRenderer>();
            spriteRendererA.sprite = hand.item.item_image;
            SpriteRenderer spriteRendererB = B.GetComponent<SpriteRenderer>();
            spriteRendererB.sprite = hand.item.item_image;
            SpriteRenderer spriteRendererC = C.GetComponent<SpriteRenderer>();
            spriteRendererC.sprite = hand.item.item_image;
            SpriteRenderer spriteRendererD = D.GetComponent<SpriteRenderer>();
            spriteRendererD.sprite = hand.item.item_image;
            SpriteRenderer spriteRendererE = E.GetComponent<SpriteRenderer>();
            spriteRendererE.sprite = hand.item.item_image;

        }
        else
        {
            crops_image.gameObject.SetActive(false);
        }
    }

}
