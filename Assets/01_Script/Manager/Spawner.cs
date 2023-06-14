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
        //������ȹ���� ���� �Ǻ���ġ ������ŭ ���͵��� HP�� �̸� �����������. ������ ����� �� �� ������ �� ����.
        if (enemyHps[hp] != 0) 
            return enemyHps[hp];
        else
        { 
            enemyHps[hp] = EnemyHp(hp - 1) + EnemyHp(hp - 2);
            return enemyHps[hp];
        }
    }
}
