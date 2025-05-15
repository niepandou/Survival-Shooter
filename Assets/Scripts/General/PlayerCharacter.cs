using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public float wuditime;
    public float wudiTimeCounter;
    public bool wudi;
    
    [Header("事件传递")] 
    public CharacterEventSO playerHealthChange;
    public VoidEventSO hurtImageFade;
    private void Update()
    {
        TimeCounter();
    }

    public override void onTakeDamage(Attack attcker, Vector3 hitPosition)
    {
        if (!wudi && !isDead)
        {
            if (currentHealth - attcker.damage> 0)
            {
                currentHealth -= attcker.damage;
                wudi = true;
                onHealthChange.Invoke(this);
            }
            else
            {
                currentHealth = 0;
                isDead = true;
                onDie.Invoke();
            }
            
            hurtImageFade.onRaisedEvent();
            playerHealthChange.onRaisedEvent(this);
        }
    }
    
    public void TimeCounter()
    {
        if (wudi)
        {
            if (wudiTimeCounter <= wuditime) wudiTimeCounter += Time.deltaTime;
            else
            {
                wudiTimeCounter = 0;
                wudi = false;
            }
        }
    }

    
}
