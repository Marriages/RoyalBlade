using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    Rigidbody2D rigid;
    float bounceForce = 5f;
    int score = 10;
    int coin=1;
    Vector2 bounceVector = Vector2.zero;
    float hp = 3f;
    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
            if(hp<1)
            {
                EnemyDie();
            }
        }

    }

    //Enemy의 HP는 피보나치 수열처럼....!
    //1 1 2 3 5 8 13 21 

    private void Awake()
    {
        rigid=GetComponent<Rigidbody2D>();
        rigid.gravityScale = 0.6f;
        bounceVector = new(0, bounceForce);
    }

    public void EnemyBounce()
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(bounceVector, ForceMode2D.Impulse);
    }
    public void EnemyHit(int damage)
    {
        Debug.Log($"Enemy Hit, Damage : {damage}, Left Life : {Hp-damage}");
        Hp -= damage;
    }
    public void EnemyDie()
    {
        Debug.Log("Enemy Die");
        Destroy(this.gameObject);
        //동전과 파편을 소환 , 점수 부여 -> prograss 진행
        UIManager.instance.UiScoreUpdate(score);
        UIManager.instance.UiCoinUpdate(coin);
        GameManager.instance.EnemyDieEffect(transform.position);
    }
    public void EnemyTouch()
    {
        rigid.velocity = Vector2.zero;
    }


}
