using UnityEngine;

public class player_attack_end : MonoBehaviour
{
    public Animator animator;

    public void OnAnimationComplete()
    {
        animator.SetInteger("onattack",-1);

    }
    public void sword_end(){
        animator.SetInteger("sword",-1);
    }
}
