using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AbilityDamageUp : ClickButtonBase
{
    protected override void OnPointerDownBehavior()
    {
        UIManager.instance.BuyDamageUp();
    }
}
