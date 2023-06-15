using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySingle : MonoBehaviour
{
    int heart;
    int score;
    int coin;
    public Action enemySingleDie;


    public void EnemySingleSetHp(int heart)    {
        this.heart = heart;
    }
    public void EnemySingleSetScore(int score)    {
        this.score = score;
    }
    public void EnemySingleSetCoin(int coin)    {
        this.coin = coin;
    }

    public void EnemySingleHit(int damage)
    {
        //.Log($"{gameObject.name} is attacked, damage : {damage}, LeftHeart : {heart-damage}");

        heart -= damage;
        if (heart <= 0)
            EnemySingleDie();
    }
    void EnemySingleDie()
    {
        //Debug.Log($"{gameObject.name} EnemySingle Die");
        GameManager.instance.EnemyDieEffect(transform.position,score,coin);
        enemySingleDie?.Invoke();
        gameObject.SetActive(false);
        //GameManager.instance.EnemyDieEffect(transform.position);
    }

}
