using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityAttackRangeUp : ClickButtonBase
{
    protected override void OnPointerDownBehavior()
    {
        UIManager.instance.BuyAttackRangeUp();
    }
}
