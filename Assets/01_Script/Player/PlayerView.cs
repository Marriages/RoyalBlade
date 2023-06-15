using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayerGuardOn()
    {
        anim.SetBool("Shield", true);
    }
    public void PlayerGuardOff()
    {
        anim.SetBool("Shield", false);
    }
    public void PlayerAttack()
    {
        anim.SetTrigger("Attack");
    }
    public void PlayerAttackSound()
    {
        AudioManager.instance.PlayerAttackSound();
    }
    public void PlayerHeartChagne(int currentHeart)
    {
        UIManager.instance.UiHeartUpdate(currentHeart);
    }
    public void PlayerDie()
    {
        anim.SetTrigger("Die");
    }
}
