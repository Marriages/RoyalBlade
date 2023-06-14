using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    PlayerSound sound;
    PlayerView view;
    PlayerModel model;
    PlayerGuardEffect guardEffect;
    PlayerWeaponDetector playerWeapon;

    private void Awake()
    {
        FindComponent();

        if(GameManager.instance != null)
            GameManager.instance.RecivePlayerController(this);
    }
    void FindComponent()
    {
        model = new PlayerModel();
        view = GetComponent<PlayerView>();
        rigid = GetComponent<Rigidbody2D>();
        guardEffect = GetComponentInChildren<PlayerGuardEffect>();
        playerWeapon = transform.GetChild(1).GetComponent<PlayerWeaponDetector>();
    }
    private void OnEnable()
    {
        playerWeapon.AttackEnemy += PlayerAttackEnemy;
    }

    void PlayerAttackEnemy(GameObject obj)
    {
        GameManager.instance.PlayerAttackEnemy(obj,model.atackPower);
    }

    public void PlayerAttack()
    {
        //Debug.Log("PlayerController : PlayerAttack()");
        view.PlayerAttack();
    }
    public void PlayerJump()
    {
        //Debug.Log("PlayerController : PlayerJump()");
        if (model.isLanding == true)
            rigid.AddForce(new(0, model.jumpPower), ForceMode2D.Impulse);
        else
            Debug.Log("PlayerController : PlayerJump() Fail : Not Landing");
    }
    public void PlayerGuardOn()
    {
        //Debug.Log("PlayerController : PlayerGuard()");
        if(model.isLanding == true)
        {
            model.isGuarding = true;
            view.PlayerGuardOn();
        }
    }
    public void PlayerGuardOff()
    {
        if (model.isLanding == true && model.isGuarding==true)
        {
            model.isGuarding = false;
            view.PlayerGuardOff();
        }
    }

    public void PlayerLanding()
    {
        //Debug.Log("PlayerController : PlayerLanding()");
        model.isLanding = true;
    }
    public void PlayerUnLanding()
    {
        //Debug.Log("PlayerController : PlayerUnLanding()");
        model.isLanding = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigid.velocity = Vector2.zero;
        if(collision.collider.CompareTag("Enemy") && model.isGuarding==true)
        {
            Debug.Log("Guard Success");
            GameManager.instance.PlayerGuardSuccess(collision.gameObject,model.guardCooltime);
            guardEffect.GuardEffectOn();
        }
        else if (collision.collider.CompareTag("Enemy") && model.isGuarding == true)
        {
            //점프중에 적과 닿음. 적의 velocity 를 0으로 만들면 끝.
        }
        else if(collision.collider.CompareTag("Enemy") && model.isLanding==true)
        {
            Debug.Log("Ouch");
            //데미지 받기
            if(model.isAlive==true)
            {
                GameManager.instance.PlayerGuardFail(collision.gameObject);
                if (model.HeartChange(-1) == true)
                {
                    view.PlayerHeartChagne(model.heart);
                }
                else
                {
                    view.PlayerHeartChagne(model.heart);
                    PlayerDie();
                }
            }
            
        }
    }
    public void PlayerDie()
    {
        if (model.isAlive == true)
            model.isAlive = false;

        view.PlayerDie();

        rigid.gravityScale = 0;
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        col.enabled = false;
    }

}
