using UnityEngine;

public class water_station : MonoBehaviour
{
    public GameObject station;
    public hand_take hand;
    public water_controller water;
    public int index;
    public Animator animate;
    private int player_in;

    private void Update()
    {
        if(player_in==1 && hand.item.item_name=="waterer" && Input.GetKeyDown(KeyCode.E)){
            water.waters[index]=50;
            animate.SetInteger("onwater",1);
            Debug.Log("補水成功");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            player_in=1;
        }  
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")) {
            player_in=0;
        }  
    }

}
