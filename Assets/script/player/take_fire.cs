using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class take_fire : MonoBehaviour
{
    public hand_take hand;
    private Light2D light;

    private void Start()
    {
        light=GetComponent<Light2D>();
        
    }
    // Update is called once per frame
    void Update()
    {   
        if(hand.item!=null){
            if(hand.item.item_name=="torch"){
                light.intensity=0.3f;
            }
            else if(hand.item.item_name=="lantern"){
                light.intensity=0.5f;
            }
            else{
                light.intensity=0f;
            }
            return; 
        }
        light.intensity=0f;
    }
}
