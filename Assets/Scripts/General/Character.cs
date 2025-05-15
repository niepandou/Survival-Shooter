using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public float getHurtDamage;
    
    public UnityEvent<Character> onHealthChange;
    public UnityEvent onDie;
    
    [Header("状态")]
    public bool isDead;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }


    public abstract void onTakeDamage(Attack attcker, Vector3 hitPosition);
    //因为需要判断是玩家还是敌人,所以直接把Character类作为基类,玩家和敌人继承这个类分别实现不同的方法


}
