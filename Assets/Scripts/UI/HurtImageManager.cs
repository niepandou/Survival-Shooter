using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HurtImageManager : MonoBehaviour
{
    public Image image;
    public float fadeDuration;
    
    public VoidEventSO fadeImage;
    
    private void OnEnable()
    {
        fadeImage.onEventRaised += fadeImageEvent;
    }

    private void OnDisable()
    {
        fadeImage.onEventRaised -= fadeImageEvent;
    }

    public void fadeImageEvent()
    {
        //淡出然后归零
        image.DOFade(30/255f, fadeDuration);

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(fadeDuration);
        image.DOFade(0,0);
    }
}
