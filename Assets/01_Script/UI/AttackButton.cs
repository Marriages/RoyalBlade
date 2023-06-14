using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : ClickButtonBase
{
    protected override void OnPointerDownBehavior()
    {
        base.OnPointerDownBehavior();
        GameManager.instance.PlayerAttack();

    }
    protected override void OnPointerUpBehavior()
    {
        base.OnPointerUpBehavior();
    }
}
