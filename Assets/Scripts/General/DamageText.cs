using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Animations;

public class DamageText : MonoBehaviour
{
    public float disapperTime;
    private TextMeshPro text;
    
    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        //执行逐渐消失的代码
        text.DOFade(0f, disapperTime);
        StartCoroutine(Destroy());
    }

    public void SetContent(float damage)
    {
        text.SetText(damage.ToString());
    }
    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }

    IEnumerator Destroy()
    {
        //等待一定时间进行销毁
        yield return new WaitForSeconds(disapperTime);

        Destroy(this.gameObject);
    }
    
}
