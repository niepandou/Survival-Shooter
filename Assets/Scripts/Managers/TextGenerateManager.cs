using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TextGenerateManager : MonoBehaviour
{
    [Header("事件监听")] 
    public TransEventSO generateText;
    
    public GameObject damageTextPrefab;

    private void OnEnable()
    {
        generateText.onEventRaised += generateDamageText;
    }

    private void OnDisable()
    {
        generateText.onEventRaised -= generateDamageText;
    }

    public void generateDamageText(Vector3 position,float damage)
    {
        GameObject newTextObj = Instantiate(damageTextPrefab,this.transform);

        if (newTextObj.TryGetComponent(out DamageText damageText))
        {
            damageText.SetContent(damage);
        }
        
        //设定合理坐标
        damageTextPrefab.transform.position = position;
    }
    
}
