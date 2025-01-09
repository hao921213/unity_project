using UnityEngine;

public class player_givefood_en : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator;
    public SpriteRenderer re;
    public void givefood_end()
    {
        animator.SetInteger("ongivefood", -1);
        re.flipX = false;
    }
}
