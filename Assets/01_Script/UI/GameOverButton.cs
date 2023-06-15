using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButton : ClickButtonBase
{
    protected override void OnPointerDownBehavior()
    {
        GameManager.instance.GameRestart();
        gameObject.SetActive(false);
    }
}
