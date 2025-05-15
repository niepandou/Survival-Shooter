using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform playerTrans;

    public bool isWalk;
    [Header("组件")]
    private NavMeshAgent nav;
    private Animator anim;
    private Rigidbody rb;
    private EnemyCharacter chara;
    private Enemy enemy;
    
    [Header("外部组件")] 
    private PlayerController player;
    
    private void Awake()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        chara = GetComponent<EnemyCharacter>();
        enemy = GetComponent<Enemy>();

        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (chara.isDead)//进行死亡的移动
        {
            if(enemy.isSinking)//死亡沉入地下
                transform.Translate(-transform.up * Time.deltaTime);
        }
        else
        {
            //活着的时候追踪玩家
            if(!player.isDead)
                nav.SetDestination(playerTrans.position);
        }
        isWalk = nav.velocity.x !=0 || nav.velocity.z != 0;
        
        AnimationSet();
    }

    private void AnimationSet()
    {
        anim.SetBool("isWalk",isWalk);
    }
}
