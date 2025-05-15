using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatBar : MonoBehaviour
{
    public CharacterEventSO playerHealthChange;
    public TextMeshProUGUI playerHealth;
    
    private void OnEnable()
    {
        playerHealthChange.onEventRaised += healthChangeEvent;
    }

    private void OnDisable()
    {
        playerHealthChange.onEventRaised -= healthChangeEvent;
    }

    public void healthChangeEvent(Character player)
    {
        playerHealth.SetText(((int)player.currentHealth).ToString() 
        + "/"
        + player.maxHealth); 
    }
}
