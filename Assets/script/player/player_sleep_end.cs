using UnityEngine;

public class player_sleep_end : MonoBehaviour
{
    public Animator animator;

    public void sleep_end()
    {
        animator.SetInteger("onsleep", -1);

    }
}
