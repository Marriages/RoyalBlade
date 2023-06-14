using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickButtonBase : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    protected float cooltime=0f;
    /*
    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClick);
    }

    virtual protected void ButtonClick()
    {
        Debug.Log($"Click Button! {gameObject.name}");
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log($"ClickButtonBase - OnClick : {gameObject.name}");
        OnPointerDownBehavior();
    }
    virtual protected void OnPointerDownBehavior()
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log($"ClickButtonBase - OnUnClick : {gameObject.name}");
        OnPointerUpBehavior();
    }
    virtual protected void OnPointerUpBehavior()
    {

    }

}
