using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStageStartButton : ClickButtonBase
{
    protected override void OnPointerDownBehavior()
    {
        transform.parent.gameObject.SetActive(false);
        GameManager.instance.NextStageStart();
        
    }
}
