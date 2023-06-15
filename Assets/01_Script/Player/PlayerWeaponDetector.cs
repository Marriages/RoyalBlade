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
    public void WeaponSizeUp()
    {
        Debug.Log($"current Scale : {transform.localScale} / AttackRangeUp : {transform.localScale*1.2f}");
        transform.localScale = transform.localScale * 1.2f;
    }
}
