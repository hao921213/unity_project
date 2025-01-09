using UnityEngine;

public class food_station : MonoBehaviour
{
    public GameObject station;
    public hand_take hand;
    public water_controller water;
    public SpriteRenderer re;
    public int index;
    public Animator animate;
    private int player_in;

    private void Update()
    {
        if (player_in == 1 && hand.item!=null && hand.item.tag == "crop" && Input.GetKeyDown(KeyCode.E))
        {
            water.waters[index] += 20;
            re.flipX = true;
            animate.SetInteger("ongivefood", 1);
            hand.item.held -= 1;
            bag_controller.RefreshItem();
            Debug.Log("¸É­¹ª«¦¨¥\");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player_in = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player_in = 0;
        }
    }
}
