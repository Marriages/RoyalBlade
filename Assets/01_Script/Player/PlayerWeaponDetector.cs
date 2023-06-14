using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponDetector : MonoBehaviour
{
    public Action<GameObject> AttackEnemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            AttackEnemy?.Invoke(collision.gameObject);
        }
    }
}
