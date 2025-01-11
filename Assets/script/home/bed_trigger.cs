using UnityEngine;

public class bed_place : MonoBehaviour
{
    public hand_take hand;
    public bag player_bag;
    public time1 time;
    private int player_in = 0;
    public Animator animator;
    public health_bar health_bar;
    private void Update()
    {
        if (player_in == 1 && Input.GetKeyDown(KeyCode.E) && (time.hour>18 || time.hour<6))
        {
            animator.SetInteger("onsleep", 1);
            time.day++;
            time.hour=8;
            time.day=0;
            health_bar.Heal(2);
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
