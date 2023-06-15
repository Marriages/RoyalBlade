using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageStartButton : ClickButtonBase
{
    protected override void OnPointerDownBehavior()
    {
        gameObject.SetActive(false);
        GameManager.instance.NextStageStart();
        
    }
}
