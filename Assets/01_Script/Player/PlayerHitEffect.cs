using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitEffect : MonoBehaviour
{
    public void EffectEnd()
    {
        gameObject.SetActive(false);
    }
}
