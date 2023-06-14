using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardButton : ClickButtonBase
{
    protected override void OnPointerDownBehavior()
    {
        base.OnPointerDownBehavior();
        GameManager.instance.PlayerGuard(true);
    }
    protected override void OnPointerUpBehavior()
    {
        base.OnPointerUpBehavior();
        GameManager.instance.PlayerGuard(false);
    }
}
