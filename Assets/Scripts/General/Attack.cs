using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Attack : MonoBehaviour
{
    [Header("基本属性")] 
    public float damage;//攻击伤害

    public float baseDamage;


    public void RandomDamage()
    {
        damage = baseDamage * Random.Range(0.8f, 1.3f);
        damage = (int)(damage * 10f) / 10f;
    }
    public void AttackTarget(Collider other,Vector3 hitPosition)
    {
        RandomDamage();
        //获取other对象的Character组件,调用里面的TakeDamage方法,让other自行进行伤害计算
        //加一个?,保证对方拥有Character这个组件
        //深层次的,?是判断获取的这个Character对象是否为空

        //玩家射击敌人
        other.GetComponent<EnemyCharacter>()?.onTakeDamage(this,hitPosition);//进行伤害
    }

    //敌人攻击玩家
    private void OnTriggerStay(Collider other)
    {
        RandomDamage();
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerCharacter>()?.onTakeDamage(this,default);//进行伤害
        }
    }
}