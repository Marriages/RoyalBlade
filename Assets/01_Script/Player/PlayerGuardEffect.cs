using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuardEffect : MonoBehaviour
{
    Color c = new(255,230,0,0);
    float ca=0;
    float effectSpeed = 5f;
    
    SpriteRenderer renderer;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();

        ca = 0f;
        c.a = ca;
        renderer.color = c;
    }

    public void GuardEffectOn()
    {
        Debug.Log("Guard Effect ON!");
        StartCoroutine(GuardEffect());
    }

    IEnumerator GuardEffect()
    {
        while(ca<1)
        {
            ca += effectSpeed * Time.deltaTime;
            c.a = ca;
            renderer.color = c;
            yield return null;
        }
        ca = 1;
        c.a = ca;
        renderer.color = c;
        while (ca > 0)
        {
            ca -= effectSpeed * Time.deltaTime;
            c.a = ca;
            renderer.color = c;
            yield return null;
        }
        c.a = 0;
        renderer.color = c;
    }
}
