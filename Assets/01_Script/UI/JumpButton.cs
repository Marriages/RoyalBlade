using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : ClickButtonBase
{
    protected override void OnPointerDownBehavior()
    {
        base.OnPointerDownBehavior();
        //Charge....!!!!!!

    }
    protected override void OnPointerUpBehavior()
    {
        base.OnPointerUpBehavior();
        GameManager.instance.PlayerJump();
    }
}
