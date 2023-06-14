using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int currentRound;
    public int maxRound;
    int[] enemyHps;

    public GameObject[] enemys;

    private void Awake()
    {
        
        EnemyHpSetting();
    }
    void EnemyHpSetting()
    {
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
}
