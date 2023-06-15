using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy의 HP값을 피보나치인데 큐에 넣어두고, 

public class Spawner : MonoBehaviour
{
    int currentRound=1;
    public int maxRound;

    int[] enemyHps;
    int[] enemyScores;
    int[] enemySpeeds= { 8, 10, 12, 14 };
    int enemySpeedIndex = -1;
    int[] enemyCoins;

    EnemySet enemySet;

    int hpIndex=0;
    public GameObject[] enemys;
    //Enemy의 width는 5, height 는 1

    private void OnEnable()
    {
        EnemyHpSetting();
        enemySet = transform.GetChild(0).GetComponent<EnemySet>();
    }
    void EnemyHpSetting()
    {
        hpIndex = 0;
        enemyHps = new int[maxRound + 1];
        enemyHps[0] = 1;
        enemyHps[1] = 1;
        EnemyHp(maxRound);
    }
    
    int EnemyHp(int hp)
    {
        //동적계획법에 따라 피보나치 수열만큼 몬스터들의 HP를 미리 결정지어놓음. 게임을 재시작 할 때 도움이 될 예정.
        if (enemyHps[hp] != 0) 
            return enemyHps[hp];
        else
        { 
            enemyHps[hp] = EnemyHp(hp - 1) + EnemyHp(hp - 2);
            return enemyHps[hp];
        }
    }

    private void Start()
    {
        UIManager.instance.UiStageUpdate(currentRound);
    }
    public int GetHp()
    {
        if(enemyHps==null)
        {
            EnemyHpSetting();
        }
        return enemyHps[hpIndex++];
    }
    public int GetScore()
    {
        return 10 * currentRound;
    }
    public int GetCoin()
    {
        return 1 * currentRound;
    }
    public int GetSpeed()
    {
        if(enemySpeedIndex+1<enemySpeeds.Length)
            enemySpeedIndex++;

        return enemySpeeds[enemySpeedIndex];
    }
    public Vector3 GetStartPosition()
    {
        return this.transform.position;
    }
    public void EnemySetDie()
    {
        UIManager.instance.NextStageReady();
        currentRound++;
    }
    public void EnemySpawnStart()
    {
        enemySet.gameObject.SetActive(true);
        UIManager.instance.UiStageUpdate(currentRound);
    }
}
