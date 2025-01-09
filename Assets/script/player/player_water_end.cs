using UnityEngine;

public class player_water_end : MonoBehaviour
{
    public Animator animator;

    public void water_end()
    {
        animator.SetInteger("onwater", -1);
    }
}
