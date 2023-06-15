using System;
using UnityEngine;
using TMPro;

public class EnemySingle : MonoBehaviour
{
    int heart;
    int score;
    int coin;
    public Action enemySingleDie;

    TextMeshProUGUI enemySingleText;
    
    private void Awake()
    {
        enemySingleText = transform.GetComponentInChildren<TextMeshProUGUI>();
    }


    public void EnemySingleSetHp(int heart)    {
        this.heart = heart;
        if(enemySingleText==null)
            enemySingleText = transform.GetComponentInChildren<TextMeshProUGUI>();
        enemySingleText.text = this.heart.ToString();
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
        enemySingleText.text = heart.ToString();
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
