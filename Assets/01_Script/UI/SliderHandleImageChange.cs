using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandleImageChange : MonoBehaviour
{
    Image img;
    public Sprite[] images = new Sprite[4];

    WaitForSeconds waitTime = new WaitForSeconds(0.2f);

    private void Awake()
    {
        img = GetComponent<Image>();
    }
    private void Start()
    {
        StartCoroutine(ImageChange());

    }
    IEnumerator ImageChange()
    {
        int i = 0;
        while(true)
        {
            img.sprite = images[(i++)%4];
            
            yield return waitTime;
        }
    }
        


}
