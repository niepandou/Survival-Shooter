using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody),typeof(CapsuleCollider)
,typeof(SphereCollider))]
[RequireComponent(typeof(NavMeshAgent),typeof(EnemyMovement),typeof(Attack))]
public class EnemyCharacter : Character
{
    public float killScore;
    [Header("组件")] 
    private ParticleSystem hitParticle;

    private CapsuleCollider collider;
    
    [Header("事件传递")] 
    public TransEventSO generateText;

    public FloatEventSO ScoreIncreaseWhenKilled;
    
    protected override void Awake()
    {
        base.Awake();
        hitParticle = GetComponentInChildren<ParticleSystem>();
        collider = GetComponent<CapsuleCollider>();
    }

    public override void onTakeDamage(Attack attcker,Vector3 hitPosition)
    {
        Vector3 topRight = collider.bounds.center 
                           + Vector3.right * collider.bounds.extents.x 
                           + Vector3.up * collider.bounds.extents.y;
        
        //发射要生成伤害文本的事件
        generateText.onEventRaised(topRight,attcker.damage);
        
        if (currentHealth - attcker.damage > 0)
        {
            //玩家攻击敌人
            currentHealth -= attcker.damage;
            hitParticle.transform.position = hitPosition;
            onHealthChange.Invoke(this);
        }
        else
        {
            currentHealth = 0;
            isDead = true;
            ScoreIncreaseWhenKilled.onRaisedEvent(killScore);
            onDie.Invoke();
        }
        
    }
}
